// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeTodoListTaskLinkedResource;

internal class Definition : ResourceDefinition
{
    public string Name => "MeTodoListTaskLinkedResource";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeTodoListByIdTaskByIdLinkedResourceOperation(),
        new DeleteMeTodoListByIdTaskByIdLinkedResourceByIdOperation(),
        new GetMeTodoListByIdTaskByIdLinkedResourceByIdOperation(),
        new GetMeTodoListByIdTaskByIdLinkedResourceCountOperation(),
        new ListMeTodoListByIdTaskByIdLinkedResourcesOperation(),
        new UpdateMeTodoListByIdTaskByIdLinkedResourceByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
