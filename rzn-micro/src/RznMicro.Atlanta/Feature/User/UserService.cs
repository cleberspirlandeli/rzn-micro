using AutoMapper;
using RznMicro.Atlanta.Core.AWS.S3;
using RznMicro.Atlanta.Core.AWS.S3.Request;
using RznMicro.Atlanta.Feature.Address.Model;
using RznMicro.Atlanta.Feature.Address.Request;
using RznMicro.Atlanta.Feature.Address.Result;
using RznMicro.Atlanta.Feature.User.Model;
using RznMicro.Atlanta.Feature.User.Request;
using RznMicro.Atlanta.Feature.User.Result;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RznMicro.Atlanta.UnitTests")]
namespace RznMicro.Atlanta.Feature.User;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserUnitOfWork _uow;
    private readonly IAwsS3Service _awsS3Service;

    public UserService(
        IMapper mapper,
        IUserUnitOfWork uow,
        IAwsS3Service awsS3Service)
    {
        _mapper = mapper;
        _uow = uow;
        _awsS3Service = awsS3Service;
    }

    public async Task<AddUserResult> AddAsync(AddUserRequest request)
    {
        ValidateAgeOver18YearsOld(request.User.DateBirth);

        var userEntity = _mapper.Map<UserEntity>(request.User);
        var addressEntity = _mapper.Map<AddressEntity>(request.Address);
        addressEntity.IdUser = userEntity.Id;

        await _uow.UserRepository.AddAsync(userEntity);
        await _uow.AddressRepository.AddAsync(addressEntity);
        await _uow.CommitAsync();

        return new AddUserResult
        {
            User = _mapper.Map<UserResult>(userEntity),
            Address = _mapper.Map<AddressResult>(addressEntity)
        };
    }

    public async Task<UpdateUserResult> UpdateAsync(UpdateUserRequest request)
    {
        ValidateAgeOver18YearsOld(request.User.DateBirth);
        var userEntity = _uow.UserRepository.GetById(request.User.Id);

        ValidateUser(userEntity);

        var addressEntity = userEntity.Address
                    .FirstOrDefault(x =>
                        x.Id == request.Address.Id &&
                        x.IdUser == request.User.Id);

        ValidateAddress(addressEntity);

        UpdateUser(userEntity, request.User);
        UpdateAddress(addressEntity, request.Address);

        await _uow.CommitAsync();

        return new UpdateUserResult
        {
            User = _mapper.Map<UserResult>(userEntity),
            Address = _mapper.Map<AddressResult>(addressEntity)
        };
    }

    public async Task<DeleteUserResult> DeleteAsync(DeleteUserRequest request)
    {
        var userEntity = await _uow.UserRepository.GetByIdAsync(request.Id);
        ValidateUser(userEntity);
        var addressEntity = userEntity.Address.FirstOrDefault();

        _uow.UserRepository.Delete(userEntity);
        await _uow.CommitAsync();

        return new DeleteUserResult
        {
            User = _mapper.Map<UserResult>(userEntity),
            Address = _mapper.Map<AddressResult>(addressEntity)
        };
    }

    public async Task<ImageUploadResult> ImageUploadAsync(ImageUploadRequest request)
    {
        var userEntity = await _uow.UserRepository.GetByIdAsync(request.IdUser);

        if (userEntity is null)
            return null;

        var upload = await _awsS3Service.PutObjectAsync(new AwsS3Request
        {
            File = request.File,
            BucketName = request.BucketName,
        });

        userEntity.AvatarKeyName = upload.ImageKey;
        userEntity.AvatarUrl = upload.Url;
        _uow.UserRepository.Edit(userEntity);
        await _uow.CommitAsync();

        var result = new ImageUploadResult
        {
            IdUser = userEntity.Id,
            ImageKey = upload.ImageKey,
            Url = upload.Url,
        };

        return result;
    }

    public async Task DeleteImageUploadAsync(string bucketName, string key)
    {
        await _awsS3Service.DeleteObjectAsync(new AwsS3Request
        {
            BucketName = bucketName,
            Key = key
        });
    }

    internal bool ExampleMethodInternal() => true;

    private void ValidateAgeOver18YearsOld(DateTime dateBirth)
    {
        var today = DateTime.Today;
        var age = today.Year - dateBirth.Year;

        if (today < dateBirth.AddYears(age))
            age--;

        if (age < 18)
            throw new Exception("User cannot be underage");
    }

    private void UpdateUser(UserEntity entity, UpdateUserDtoRequest request)
    {
        entity.FullName = request.FullName;
        entity.DateBirth = request.DateBirth;
        entity.Active = request.Active;
        entity.Gender = request.Gender;

        _uow.UserRepository.Edit(entity);
    }

    private void UpdateAddress(AddressEntity entity, UpdateAddressDtoRequest request)
    {
        entity.ZipCode = request.ZipCode;
        entity.Street = request.Street;
        entity.Number = request.Number;
        entity.AdditionalInformation = request.AdditionalInformation;
        entity.TypeOfAddress = request.TypeOfAddress;

        _uow.AddressRepository.Edit(entity);
    }

    private static void ValidateUser(UserEntity? userEntity)
    {
        if (userEntity is null)
            throw new Exception("User not exists");
    }

    private static void ValidateAddress(AddressEntity? addressEntity)
    {
        if (addressEntity is null)
            throw new Exception("Address not exists");
    }

}
