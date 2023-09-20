// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarCalendarViewExceptionOccurrenceExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarCalendarViewExceptionOccurrenceExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdExtensionOperation(),
        new CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdExtensionOperation(),
        new DeleteMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new DeleteMeCalendarCalendarViewByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new GetMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new GetMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdExtensionCountOperation(),
        new GetMeCalendarCalendarViewByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new GetMeCalendarCalendarViewByIdExceptionOccurrenceByIdExtensionCountOperation(),
        new ListMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdExtensionsOperation(),
        new ListMeCalendarCalendarViewByIdExceptionOccurrenceByIdExtensionsOperation(),
        new UpdateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new UpdateMeCalendarCalendarViewByIdExceptionOccurrenceByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
