// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarEventExceptionOccurrenceInstanceExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarEventExceptionOccurrenceInstanceExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdExtensionOperation(),
        new CreateMeCalendarEventByIdExceptionOccurrenceByIdInstanceByIdExtensionOperation(),
        new DeleteMeCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdExtensionByIdOperation(),
        new DeleteMeCalendarEventByIdExceptionOccurrenceByIdInstanceByIdExtensionByIdOperation(),
        new GetMeCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdExtensionByIdOperation(),
        new GetMeCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdExtensionCountOperation(),
        new GetMeCalendarEventByIdExceptionOccurrenceByIdInstanceByIdExtensionByIdOperation(),
        new GetMeCalendarEventByIdExceptionOccurrenceByIdInstanceByIdExtensionCountOperation(),
        new ListMeCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdExtensionsOperation(),
        new ListMeCalendarEventByIdExceptionOccurrenceByIdInstanceByIdExtensionsOperation(),
        new UpdateMeCalendarByIdEventByIdExceptionOccurrenceByIdInstanceByIdExtensionByIdOperation(),
        new UpdateMeCalendarEventByIdExceptionOccurrenceByIdInstanceByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
