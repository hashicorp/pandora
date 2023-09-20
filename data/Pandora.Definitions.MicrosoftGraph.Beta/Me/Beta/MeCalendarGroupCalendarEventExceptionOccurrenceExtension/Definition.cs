// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarGroupCalendarEventExceptionOccurrenceExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarGroupCalendarEventExceptionOccurrenceExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdExtensionOperation(),
        new DeleteMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new GetMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new GetMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdExtensionCountOperation(),
        new ListMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdExtensionsOperation(),
        new UpdateMeCalendarGroupByIdCalendarByIdEventByIdExceptionOccurrenceByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
