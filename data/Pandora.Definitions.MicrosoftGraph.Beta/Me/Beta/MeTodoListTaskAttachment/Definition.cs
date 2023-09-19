// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeTodoListTaskAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "MeTodoListTaskAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeTodoListByIdTaskByIdAttachmentCreateUploadSessionOperation(),
        new CreateMeTodoListByIdTaskByIdAttachmentOperation(),
        new CreateUpdateMeTodoListByIdTaskByIdAttachmentByIdValueOperation(),
        new DeleteMeTodoListByIdTaskByIdAttachmentByIdOperation(),
        new GetMeTodoListByIdTaskByIdAttachmentByIdOperation(),
        new GetMeTodoListByIdTaskByIdAttachmentByIdValueOperation(),
        new GetMeTodoListByIdTaskByIdAttachmentCountOperation(),
        new ListMeTodoListByIdTaskByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeTodoListByIdTaskByIdAttachmentCreateUploadSessionRequestModel)
    };
}
