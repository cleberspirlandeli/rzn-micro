using Microsoft.Extensions.DependencyInjection;
using RznMicro.Atlanta.Database.Feature;
using RznMicro.Atlanta.Database.Repository.Feature;
using RznMicro.Atlanta.Database.UnitOfWork.Base;
using RznMicro.Atlanta.Feature.Address;
using RznMicro.Atlanta.Feature.User;

namespace RznMicro.Atlanta.Database.UnitOfWork.Feature;

public class UserUnitOfWork : GenericUnitOfWork, IUserUnitOfWork
{
    public UserUnitOfWork(DefaultDataBaseContext context, IServiceProvider serviceProvider)
        : base(context, serviceProvider) { }

    public IUserRepository UserRepository => _serviceProvider.GetService<UserRepository>();
    public IAddressRepository AddressRepository => _serviceProvider.GetService<AddressRepository>();
}
