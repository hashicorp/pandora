// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeEventExceptionOccurrence;

internal class Definition : ResourceDefinition
{
    public string Name => "MeEventExceptionOccurrence";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeEventByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateMeEventByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateMeEventByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateMeEventByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateMeEventByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateMeEventByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateMeEventByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new GetMeEventByIdExceptionOccurrenceByIdOperation(),
        new GetMeEventByIdExceptionOccurrenceCountOperation(),
        new ListMeEventByIdExceptionOccurrencesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeEventByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateMeEventByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateMeEventByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateMeEventByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateMeEventByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateMeEventByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel)
    };
}
