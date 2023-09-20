// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarEventExceptionOccurrenceExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarEventExceptionOccurrenceExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdExtensionOperation(),
        new CreateMeCalendarEventByIdExceptionOccurrenceByIdExtensionOperation(),
        new DeleteMeCalendarByIdEventByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new DeleteMeCalendarEventByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new GetMeCalendarByIdEventByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new GetMeCalendarByIdEventByIdExceptionOccurrenceByIdExtensionCountOperation(),
        new GetMeCalendarEventByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new GetMeCalendarEventByIdExceptionOccurrenceByIdExtensionCountOperation(),
        new ListMeCalendarByIdEventByIdExceptionOccurrenceByIdExtensionsOperation(),
        new ListMeCalendarEventByIdExceptionOccurrenceByIdExtensionsOperation(),
        new UpdateMeCalendarByIdEventByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new UpdateMeCalendarEventByIdExceptionOccurrenceByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
