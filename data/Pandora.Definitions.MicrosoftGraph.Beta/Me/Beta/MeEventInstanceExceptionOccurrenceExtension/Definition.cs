// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeEventInstanceExceptionOccurrenceExtension;

internal class Definition : ResourceDefinition
{
    public string Name => "MeEventInstanceExceptionOccurrenceExtension";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeEventByIdInstanceByIdExceptionOccurrenceByIdExtensionOperation(),
        new DeleteMeEventByIdInstanceByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new GetMeEventByIdInstanceByIdExceptionOccurrenceByIdExtensionByIdOperation(),
        new GetMeEventByIdInstanceByIdExceptionOccurrenceByIdExtensionCountOperation(),
        new ListMeEventByIdInstanceByIdExceptionOccurrenceByIdExtensionsOperation(),
        new UpdateMeEventByIdInstanceByIdExceptionOccurrenceByIdExtensionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
