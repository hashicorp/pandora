// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarGroupCalendarEventInstanceExceptionOccurrenceExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarGroupCalendarEventInstanceExceptionOccurrenceExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdExtensionOperation(),
        new DeleteMeCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new GetMeCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new GetMeCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdExtensionCountOperation(),
        new ListMeCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdExtensionsOperation(),
        new UpdateMeCalendarGroupByIdCalendarByIdEventByIdInstanceByIdExceptionOccurrenceByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
