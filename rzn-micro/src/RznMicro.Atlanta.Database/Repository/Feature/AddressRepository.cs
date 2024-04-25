using RznMicro.Atlanta.Database.Feature;
using RznMicro.Atlanta.Database.Repository.Base;
using RznMicro.Atlanta.Feature.Address;
using RznMicro.Atlanta.Feature.Address.Model;

namespace RznMicro.Atlanta.Database.Repository.Feature;

public class AddressRepository : GenericRepository<AddressEntity, DefaultDataBaseContext>, IAddressRepository
{
    public AddressRepository(DefaultDataBaseContext context) : base(context) { }
}
