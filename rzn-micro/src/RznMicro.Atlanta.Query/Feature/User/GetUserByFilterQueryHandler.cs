using AutoMapper;
using RznMicro.Atlanta.Contract.Feature.User.Query;
using RznMicro.Atlanta.Contract.Feature.User.Result;
using RznMicro.Atlanta.Core.RequestContext;

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

    public async Task<GetUserByFilterQueryResult> Handle(GetUserByFilterQuery request, CancellationToken cancellationToken)
    {
        var result = await _userQueryRepository.GetAllAsync();

        var x = new GetUserByFilterQueryResult
        {
            Users = result
        };

        return x;
    }
}
