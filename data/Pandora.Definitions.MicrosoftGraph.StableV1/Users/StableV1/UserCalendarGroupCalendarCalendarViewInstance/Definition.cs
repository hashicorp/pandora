// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserCalendarGroupCalendarCalendarViewInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCalendarGroupCalendarCalendarViewInstance";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdAcceptOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdCancelOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdDeclineOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdDismissReminderOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdForwardOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdSnoozeReminderOperation(),
        new CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdTentativelyAcceptOperation(),
        new GetUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdOperation(),
        new GetUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceCountOperation(),
        new ListUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdInstancesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdAcceptRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdCancelRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdDeclineRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdForwardRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdInstanceByIdTentativelyAcceptRequestModel)
    };
}
