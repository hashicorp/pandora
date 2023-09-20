// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarCalendarViewExceptionOccurrenceInstanceExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarCalendarViewExceptionOccurrenceInstanceExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdExtensionOperation(),
        new CreateMeCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdExtensionOperation(),
        new DeleteMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdExtensionByIdOperation(),
        new DeleteMeCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdExtensionByIdOperation(),
        new GetMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdExtensionByIdOperation(),
        new GetMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdExtensionCountOperation(),
        new GetMeCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdExtensionByIdOperation(),
        new GetMeCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdExtensionCountOperation(),
        new ListMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdExtensionsOperation(),
        new ListMeCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdExtensionsOperation(),
        new UpdateMeCalendarByIdCalendarViewByIdExceptionOccurrenceByIdInstanceByIdExtensionByIdOperation(),
        new UpdateMeCalendarCalendarViewByIdExceptionOccurrenceByIdInstanceByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
