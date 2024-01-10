// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarViewExceptionOccurrenceInstanceExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarViewExceptionOccurrenceInstanceExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarViewByIdExceptionOccurrenceByIdInstanceByIdExtensionOperation(),
        new DeleteMeCalendarViewByIdExceptionOccurrenceByIdInstanceByIdExtensionByIdOperation(),
        new GetMeCalendarViewByIdExceptionOccurrenceByIdInstanceByIdExtensionByIdOperation(),
        new GetMeCalendarViewByIdExceptionOccurrenceByIdInstanceByIdExtensionCountOperation(),
        new ListMeCalendarViewByIdExceptionOccurrenceByIdInstanceByIdExtensionsOperation(),
        new UpdateMeCalendarViewByIdExceptionOccurrenceByIdInstanceByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
