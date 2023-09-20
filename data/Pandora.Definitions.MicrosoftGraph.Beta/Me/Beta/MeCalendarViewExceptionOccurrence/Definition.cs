// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarViewExceptionOccurrence;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarViewExceptionOccurrence";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarViewByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateMeCalendarViewByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateMeCalendarViewByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateMeCalendarViewByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateMeCalendarViewByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateMeCalendarViewByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateMeCalendarViewByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new GetMeCalendarViewByIdExceptionOccurrenceByIdOperation(),
        new GetMeCalendarViewByIdExceptionOccurrenceCountOperation(),
        new ListMeCalendarViewByIdExceptionOccurrencesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarViewByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateMeCalendarViewByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateMeCalendarViewByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateMeCalendarViewByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateMeCalendarViewByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateMeCalendarViewByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel)
    };
}
