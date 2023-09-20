// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeEventExceptionOccurrenceExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "MeEventExceptionOccurrenceExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeEventByIdExceptionOccurrenceByIdExtensionOperation(),
        new DeleteMeEventByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new GetMeEventByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new GetMeEventByIdExceptionOccurrenceByIdExtensionCountOperation(),
        new ListMeEventByIdExceptionOccurrenceByIdExtensionsOperation(),
        new UpdateMeEventByIdExceptionOccurrenceByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
