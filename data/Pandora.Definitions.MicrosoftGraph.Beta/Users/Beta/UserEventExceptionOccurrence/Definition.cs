// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserEventExceptionOccurrence;

internal class Definition : ResourceDefinition
{
    public string Name => "UserEventExceptionOccurrence";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdEventByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateUserByIdEventByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateUserByIdEventByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateUserByIdEventByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateUserByIdEventByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateUserByIdEventByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateUserByIdEventByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new GetUserByIdEventByIdExceptionOccurrenceByIdOperation(),
        new GetUserByIdEventByIdExceptionOccurrenceCountOperation(),
        new ListUserByIdEventByIdExceptionOccurrencesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdEventByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateUserByIdEventByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateUserByIdEventByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateUserByIdEventByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateUserByIdEventByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateUserByIdEventByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel)
    };
}
