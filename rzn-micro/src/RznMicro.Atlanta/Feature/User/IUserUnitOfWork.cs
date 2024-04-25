using RznMicro.Atlanta.Common;
using RznMicro.Atlanta.Feature.Address;

namespace RznMicro.Atlanta.Feature.User;

public interface IUserUnitOfWork : IGenericUnitOfWork
{
    public IUserRepository UserRepository { get; }
    public IAddressRepository AddressRepository { get; }
}
