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
}
