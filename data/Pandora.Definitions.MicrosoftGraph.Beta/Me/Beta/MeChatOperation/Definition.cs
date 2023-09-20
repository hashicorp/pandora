// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeChatOperation;

internal class Definition : ResourceDefinition
{
    public string Name => "MeChatOperation";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeChatByIdOperationOperation(),
        new DeleteMeChatByIdOperationByIdOperation(),
        new GetMeChatByIdOperationByIdOperation(),
        new GetMeChatByIdOperationCountOperation(),
        new ListMeChatByIdOperationsOperation(),
        new UpdateMeChatByIdOperationByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
