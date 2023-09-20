// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCalendarViewInstanceExceptionOccurrenceExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCalendarViewInstanceExceptionOccurrenceExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCalendarViewByIdInstanceByIdExceptionOccurrenceByIdExtensionOperation(),
        new DeleteMeCalendarViewByIdInstanceByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new GetMeCalendarViewByIdInstanceByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new GetMeCalendarViewByIdInstanceByIdExceptionOccurrenceByIdExtensionCountOperation(),
        new ListMeCalendarViewByIdInstanceByIdExceptionOccurrenceByIdExtensionsOperation(),
        new UpdateMeCalendarViewByIdInstanceByIdExceptionOccurrenceByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
