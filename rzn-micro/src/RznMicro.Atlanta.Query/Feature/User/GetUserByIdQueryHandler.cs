using AutoMapper;
using RznMicro.Atlanta.Contract.Feature.User;
using RznMicro.Atlanta.Core.RequestContext;
using RznMicro.Atlanta.Feature.User;

namespace RznMicro.Atlanta.Query.Feature.User;

public sealed class GetUserByIdQueryHandler : ICommandHandler<GetUserByIdQuery, AddUserCommandResult>
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

    public async Task<AddUserCommandResult> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _userQueryRepository.GetByIdAsync(query.IdUser);

        return null;
    }
}
