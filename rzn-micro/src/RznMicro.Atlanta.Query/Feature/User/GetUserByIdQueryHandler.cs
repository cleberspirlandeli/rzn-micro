﻿using AutoMapper;
using RznMicro.Atlanta.Contract.Feature.User.Query;
using RznMicro.Atlanta.Contract.Feature.User.Result;
using RznMicro.Atlanta.Core.RequestContext;

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
        var result = await _userQueryRepository.GetByIdAsync(query.IdUser);
        return result;
    }
}
