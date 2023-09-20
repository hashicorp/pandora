// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupEventInstanceExceptionOccurrence;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupEventInstanceExceptionOccurrence";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdEventByIdInstanceByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateGroupByIdEventByIdInstanceByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateGroupByIdEventByIdInstanceByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateGroupByIdEventByIdInstanceByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateGroupByIdEventByIdInstanceByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateGroupByIdEventByIdInstanceByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateGroupByIdEventByIdInstanceByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new GetGroupByIdEventByIdInstanceByIdExceptionOccurrenceByIdOperation(),
        new GetGroupByIdEventByIdInstanceByIdExceptionOccurrenceCountOperation(),
        new ListGroupByIdEventByIdInstanceByIdExceptionOccurrencesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdEventByIdInstanceByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateGroupByIdEventByIdInstanceByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateGroupByIdEventByIdInstanceByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateGroupByIdEventByIdInstanceByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateGroupByIdEventByIdInstanceByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateGroupByIdEventByIdInstanceByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel)
    };
}
