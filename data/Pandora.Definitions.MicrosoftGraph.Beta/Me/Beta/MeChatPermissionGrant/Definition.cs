// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeChatPermissionGrant;

internal class Definition : ResourceDefinition
{
    public string Name => "MeChatPermissionGrant";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeChatByIdPermissionGrantOperation(),
        new DeleteMeChatByIdPermissionGrantByIdOperation(),
        new GetMeChatByIdPermissionGrantByIdOperation(),
        new GetMeChatByIdPermissionGrantCountOperation(),
        new ListMeChatByIdPermissionGrantsOperation(),
        new UpdateMeChatByIdPermissionGrantByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
