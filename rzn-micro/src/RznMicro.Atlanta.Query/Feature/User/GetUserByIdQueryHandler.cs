using AutoMapper;
using RznMicro.Atlanta.Contract.Feature.Address.Result;
using RznMicro.Atlanta.Contract.Feature.User.Query;
using RznMicro.Atlanta.Contract.Feature.User.Result;
using RznMicro.Atlanta.Core.RequestContext;
using RznMicro.Atlanta.Enumerable;
using System.Globalization;

namespace RznMicro.Atlanta.Query.Feature.User;

public sealed class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, GetUserQueryResult>
{
    private readonly IMapper _mapper;
    private readonly IUserQueryRepository _userQueryRepository;

    public GetUserByIdQueryHandler(
        IMapper mapper, 
        IUserQueryRepository userQueryRepository)
    {
        _mapper = mapper;
        _userQueryRepository = userQueryRepository;
    }

    public async Task<GetUserQueryResult> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
    {
        var user = await _userQueryRepository.GetByIdAsync(query.IdUser);

        var result = new GetUserQueryResult
        {
            User = new UserQueryResult
            {
                Id = new Guid(user.IdUser),
                FullName = user.FullName,
                DateBirth = DateTime.ParseExact(user.DateBirth, "yyyy/MM/dd", CultureInfo.InvariantCulture),
                Active = user.Active,
                Gender = user?.Gender is not null ? (GenderEnum)user.Gender : null,
            },
            Address = new AddressQueryResult
            {
                Id = user.IdAddress,
                IdUser = user.IdUser,
                Street = user.Street,
                Number = user.Number,
                ZipCode = user.ZipCode,
                AdditionalInformation = user.AdditionalInformation,
                TypeOfAddress = user?.TypeOfAddress is not null ? (TypeOfAddressEnum)user.TypeOfAddress : null,
            }
        };

        return result;
    }
}
