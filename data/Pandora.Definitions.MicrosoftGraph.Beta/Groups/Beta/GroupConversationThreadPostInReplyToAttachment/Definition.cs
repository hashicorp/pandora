// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupConversationThreadPostInReplyToAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupConversationThreadPostInReplyToAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdConversationByIdThreadByIdPostByIdInReplyToAttachmentCreateUploadSessionOperation(),
        new CreateGroupByIdConversationByIdThreadByIdPostByIdInReplyToAttachmentOperation(),
        new DeleteGroupByIdConversationByIdThreadByIdPostByIdInReplyToAttachmentByIdOperation(),
        new GetGroupByIdConversationByIdThreadByIdPostByIdInReplyToAttachmentByIdOperation(),
        new GetGroupByIdConversationByIdThreadByIdPostByIdInReplyToAttachmentCountOperation(),
        new ListGroupByIdConversationByIdThreadByIdPostByIdInReplyToAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdConversationByIdThreadByIdPostByIdInReplyToAttachmentCreateUploadSessionRequestModel)
    };
}
