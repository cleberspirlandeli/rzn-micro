using AutoMapper;
using RznMicro.Atlanta.Core.AWS.S3;
using RznMicro.Atlanta.Core.AWS.S3.Request;
using RznMicro.Atlanta.Feature.Address.Model;
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

    public async Task<AlterUserResult> AlterAsync(AlterUserRequest request)
    {
        return new AlterUserResult
        {
            Id = Guid.NewGuid()
        };
    }

    public async Task<DeleteUserResult> DeleteAsync(DeleteUserRequest request)
    {
        return new DeleteUserResult
        {
            Id = Guid.NewGuid()
        };
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

    public async Task<ImageUploadResult> ImageUploadAsync(ImageUploadRequest request)
    {
        //var user = await _uow.UserRepository.GetByIdAsync(request.IdUser);

        //if (user is null)
        //    return null;

        var upload = await _awsS3Service.PutObjectAsync(new AwsS3Request
        {
            BucketName = request.BucketName,
            ImageName = request.ImageName,
            File = request.File
        });

        //user.AvatarKeyName = upload.ImageKey;
        //user.AvatarUrl = upload.Url;

        //await _uow.CommitAsync();

        var result = new ImageUploadResult
        {
            ImageKey = upload.ImageKey,
            Url = upload.Url,
        };

        return result;
    }
}
