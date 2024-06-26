﻿using RznMicro.Atlanta.Contract.Feature.Address.Request;
using RznMicro.Atlanta.Contract.Feature.User.Request;
using RznMicro.Atlanta.Contract.Feature.User.Result;
using RznMicro.Atlanta.Core.RequestContext;

namespace RznMicro.Atlanta.Contract.Feature.User.Command;

public class AddUserCommand : ICommand<AddUserCommandResult>
{
    public AddUserCommandRequest User { get; set; }
    public AddAddressCommandRequest Address { get; set; }
}
