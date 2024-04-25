using AutoMapper;
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


    public UserService(IMapper mapper, IUserUnitOfWork uow)
    {
        _mapper = mapper;
        _uow = uow;
    }

    public async Task<AddUserResult> AddAsync(AddUserRequest request)
    {
        ValidateAgeOver18YearsOld(request.User.DateBirth);

        var user = _mapper.Map<UserEntity>(request.User);
        //var address = _mapper.Map<AddressEntity>(request.Address.FirstOrDefault());
        //address.IdUser = user.Id;

        await _uow.UserRepository.AddAsync(user);
        //await _uow.AddressRepository.AddAsync(address);
        _uow.Rollback();

        return new AddUserResult
        {
            User = new UserResult
            {
                Id = user.Id,
                FullName = user.FullName,
                DateBirth = user.DateBirth,
                Active = user.Active,
                Gender = user.Gender,
            },
            Address = new AddressResult
            {
                //Id = address.Id,
                //IdUser = address.IdUser,
                //ZipCode = address.ZipCode,
                //Street = address.Street,
                //Number = address.Number,
                //AdditionalInformation = address.AdditionalInformation,
                //TypeOfAddress = address.TypeOfAddress,
            }
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
}
