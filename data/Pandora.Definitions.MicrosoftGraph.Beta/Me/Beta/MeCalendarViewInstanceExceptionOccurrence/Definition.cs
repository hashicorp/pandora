// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarViewInstanceExceptionOccurrence;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarViewInstanceExceptionOccurrence";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAcceptOperation(),
        new CreateMeCalendarViewByIdInstanceByIdExceptionOccurrenceByIdCancelOperation(),
        new CreateMeCalendarViewByIdInstanceByIdExceptionOccurrenceByIdDeclineOperation(),
        new CreateMeCalendarViewByIdInstanceByIdExceptionOccurrenceByIdDismissReminderOperation(),
        new CreateMeCalendarViewByIdInstanceByIdExceptionOccurrenceByIdForwardOperation(),
        new CreateMeCalendarViewByIdInstanceByIdExceptionOccurrenceByIdSnoozeReminderOperation(),
        new CreateMeCalendarViewByIdInstanceByIdExceptionOccurrenceByIdTentativelyAcceptOperation(),
        new GetMeCalendarViewByIdInstanceByIdExceptionOccurrenceByIdOperation(),
        new GetMeCalendarViewByIdInstanceByIdExceptionOccurrenceCountOperation(),
        new ListMeCalendarViewByIdInstanceByIdExceptionOccurrencesOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCalendarViewByIdInstanceByIdExceptionOccurrenceByIdAcceptRequestModel),
        typeof(CreateMeCalendarViewByIdInstanceByIdExceptionOccurrenceByIdCancelRequestModel),
        typeof(CreateMeCalendarViewByIdInstanceByIdExceptionOccurrenceByIdDeclineRequestModel),
        typeof(CreateMeCalendarViewByIdInstanceByIdExceptionOccurrenceByIdForwardRequestModel),
        typeof(CreateMeCalendarViewByIdInstanceByIdExceptionOccurrenceByIdSnoozeReminderRequestModel),
        typeof(CreateMeCalendarViewByIdInstanceByIdExceptionOccurrenceByIdTentativelyAcceptRequestModel)
    };
}
