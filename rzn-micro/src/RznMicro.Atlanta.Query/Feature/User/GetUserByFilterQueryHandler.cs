using AutoMapper;
using RznMicro.Atlanta.Contract.Feature.Address.Result;
using RznMicro.Atlanta.Contract.Feature.User.Query;
using RznMicro.Atlanta.Contract.Feature.User.Request;
using RznMicro.Atlanta.Contract.Feature.User.Result;
using RznMicro.Atlanta.Core.RequestContext;
using RznMicro.Atlanta.Enumerable;
using System.Globalization;

namespace RznMicro.Atlanta.Query.Feature.User;

public sealed class GetUserByFilterQueryHandler : IQueryHandler<GetUserByFilterQuery, GetUserByFilterQueryResult>
{
    private readonly IMapper _mapper;
    private readonly IUserQueryRepository _userQueryRepository;

    public GetUserByFilterQueryHandler(
        IMapper mapper, 
        IUserQueryRepository userQueryRepository)
    {
        _mapper = mapper;
        _userQueryRepository = userQueryRepository;
    }

    public async Task<GetUserByFilterQueryResult> Handle(GetUserByFilterQuery query, CancellationToken cancellationToken)
    {
        // TODO: Implement pagination
        var request = new GetAllByFilterQueryRequest
        {
            IdUser = query.IdUser,
            IdAddress = query.IdAddress,
            FullName = query.FullName,
            //Skip
        };

        var userList = await _userQueryRepository.GetAllByFilterAsync(request);

        var userQueryResult = userList.Select(x => new GetUserQueryResult
        {
            User = new UserQueryResult
            {
                Id = new Guid(x.IdUser),
                FullName = x.FullName,
                DateBirth = DateTime.ParseExact(x.DateBirth, "yyyy/MM/dd", CultureInfo.InvariantCulture),
                Active = x.Active,
                Gender = x?.Gender is not null ? (GenderEnum)x.Gender : null,
                AvatarUrl = x?.AvatarUrl,
                AvatarKeyName = x?.AvatarKeyName,
            },
            Address = new AddressQueryResult
            {
                Id = x.IdAddress,
                IdUser = x.IdUser,
                Street = x.Street,
                Number = x.Number,
                ZipCode = x.ZipCode,
                AdditionalInformation = x.AdditionalInformation,
                TypeOfAddress = x?.TypeOfAddress is not null ? (TypeOfAddressEnum)x.TypeOfAddress : null,
            }
        });

        var result = new GetUserByFilterQueryResult(userQueryResult);
        return result;
    }
}
