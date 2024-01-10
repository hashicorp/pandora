// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupThreadPostAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupThreadPostAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdThreadByIdPostByIdAttachmentCreateUploadSessionOperation(),
        new CreateGroupByIdThreadByIdPostByIdAttachmentOperation(),
        new DeleteGroupByIdThreadByIdPostByIdAttachmentByIdOperation(),
        new GetGroupByIdThreadByIdPostByIdAttachmentByIdOperation(),
        new GetGroupByIdThreadByIdPostByIdAttachmentCountOperation(),
        new ListGroupByIdThreadByIdPostByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdThreadByIdPostByIdAttachmentCreateUploadSessionRequestModel)
    };
}
