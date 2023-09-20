// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeTodoListTaskAttachmentSession;

internal class Definition : ResourceDefinition
{
    public string Name => "MeTodoListTaskAttachmentSession";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DeleteMeTodoListByIdTaskByIdAttachmentSessionByIdOperation(),
        new GetMeTodoListByIdTaskByIdAttachmentSessionByIdOperation(),
        new GetMeTodoListByIdTaskByIdAttachmentSessionCountOperation(),
        new ListMeTodoListByIdTaskByIdAttachmentSessionsOperation(),
        new UpdateMeTodoListByIdTaskByIdAttachmentSessionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
