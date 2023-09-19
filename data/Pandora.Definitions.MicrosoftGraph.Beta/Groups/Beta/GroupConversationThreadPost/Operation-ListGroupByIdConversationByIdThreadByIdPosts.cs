// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupConversationThreadPost;

internal class ListGroupByIdConversationByIdThreadByIdPostsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new GroupIdConversationIdThreadId();
    public override Type NestedItemType() => typeof(PostCollectionResponseModel);
    public override string? UriSuffix() => "/posts";
}
