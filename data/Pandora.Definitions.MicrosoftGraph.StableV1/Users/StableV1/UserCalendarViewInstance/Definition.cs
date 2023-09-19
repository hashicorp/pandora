// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserCalendarViewInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarViewInstance";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarViewByIdInstanceByIdAcceptOperation(),
        new CreateUserByIdCalendarViewByIdInstanceByIdCancelOperation(),
        new CreateUserByIdCalendarViewByIdInstanceByIdDeclineOperation(),
        new CreateUserByIdCalendarViewByIdInstanceByIdDismissReminderOperation(),
        new CreateUserByIdCalendarViewByIdInstanceByIdForwardOperation(),
        new CreateUserByIdCalendarViewByIdInstanceByIdSnoozeReminderOperation(),
        new CreateUserByIdCalendarViewByIdInstanceByIdTentativelyAcceptOperation(),
        new GetUserByIdCalendarViewByIdInstanceByIdOperation(),
        new GetUserByIdCalendarViewByIdInstanceCountOperation(),
        new ListUserByIdCalendarViewByIdInstancesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarViewByIdInstanceByIdAcceptRequestModel),
        typeof(CreateUserByIdCalendarViewByIdInstanceByIdCancelRequestModel),
        typeof(CreateUserByIdCalendarViewByIdInstanceByIdDeclineRequestModel),
        typeof(CreateUserByIdCalendarViewByIdInstanceByIdForwardRequestModel),
        typeof(CreateUserByIdCalendarViewByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdCalendarViewByIdInstanceByIdTentativelyAcceptRequestModel)
    };
}
