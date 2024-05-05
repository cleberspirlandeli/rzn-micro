using RznMicro.Atlanta.Contract.Feature.Address.Result;
using RznMicro.Atlanta.Core.RequestContext;
using System.Text.Json.Serialization;

namespace RznMicro.Atlanta.Contract.Feature.User.Result;

public record GetUserQueryResult : IQueryResult
{
    public UserQueryResult User { get; set; }
    public AddressQueryResult Address { get; set; }
}
