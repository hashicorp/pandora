// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupEventExceptionOccurrence;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupEventExceptionOccurrence";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdEventByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateGroupByIdEventByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateGroupByIdEventByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateGroupByIdEventByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateGroupByIdEventByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateGroupByIdEventByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateGroupByIdEventByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new GetGroupByIdEventByIdExceptionOccurrenceByIdOperation(),
        new GetGroupByIdEventByIdExceptionOccurrenceCountOperation(),
        new ListGroupByIdEventByIdExceptionOccurrencesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdEventByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateGroupByIdEventByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateGroupByIdEventByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateGroupByIdEventByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateGroupByIdEventByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateGroupByIdEventByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel)
    };
}
