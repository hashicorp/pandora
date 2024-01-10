// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupConversationThreadPostAttachment;

internal class ListGroupByIdConversationByIdThreadByIdPostByIdAttachmentsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new GroupIdConversationIdThreadIdPostId();
    public override Type NestedItemType() => typeof(AttachmentCollectionResponseModel);
    public override string? UriSuffix() => "/attachments";
}
