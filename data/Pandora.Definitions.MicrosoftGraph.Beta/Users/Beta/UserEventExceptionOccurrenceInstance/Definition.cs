// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserEventExceptionOccurrenceInstance;

internal class Definition : ResourceDefinition
{
    public string Name => "UserEventExceptionOccurrenceInstance";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdEventByIdExceptionOccurrenceByIdInstanceByIdAcceptOperation(),
        new CreateUserByIdEventByIdExceptionOccurrenceByIdInstanceByIdCancelOperation(),
        new CreateUserByIdEventByIdExceptionOccurrenceByIdInstanceByIdDeclineOperation(),
        new CreateUserByIdEventByIdExceptionOccurrenceByIdInstanceByIdDismissReminderOperation(),
        new CreateUserByIdEventByIdExceptionOccurrenceByIdInstanceByIdForwardOperation(),
        new CreateUserByIdEventByIdExceptionOccurrenceByIdInstanceByIdSnoozeReminderOperation(),
        new CreateUserByIdEventByIdExceptionOccurrenceByIdInstanceByIdTentativelyAcceptOperation(),
        new GetUserByIdEventByIdExceptionOccurrenceByIdInstanceByIdOperation(),
        new GetUserByIdEventByIdExceptionOccurrenceByIdInstanceCountOperation(),
        new ListUserByIdEventByIdExceptionOccurrenceByIdInstancesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdEventByIdExceptionOccurrenceByIdInstanceByIdAcceptRequestModel),
        typeof(CreateUserByIdEventByIdExceptionOccurrenceByIdInstanceByIdCancelRequestModel),
        typeof(CreateUserByIdEventByIdExceptionOccurrenceByIdInstanceByIdDeclineRequestModel),
        typeof(CreateUserByIdEventByIdExceptionOccurrenceByIdInstanceByIdForwardRequestModel),
        typeof(CreateUserByIdEventByIdExceptionOccurrenceByIdInstanceByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdEventByIdExceptionOccurrenceByIdInstanceByIdTentativelyAcceptRequestModel)
    };
}
