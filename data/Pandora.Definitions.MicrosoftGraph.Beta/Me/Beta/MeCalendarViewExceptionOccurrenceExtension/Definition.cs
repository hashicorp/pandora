// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarViewExceptionOccurrenceExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarViewExceptionOccurrenceExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarViewByIdExceptionOccurrenceByIdExtensionOperation(),
        new DeleteMeCalendarViewByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new GetMeCalendarViewByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new GetMeCalendarViewByIdExceptionOccurrenceByIdExtensionCountOperation(),
        new ListMeCalendarViewByIdExceptionOccurrenceByIdExtensionsOperation(),
        new UpdateMeCalendarViewByIdExceptionOccurrenceByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
