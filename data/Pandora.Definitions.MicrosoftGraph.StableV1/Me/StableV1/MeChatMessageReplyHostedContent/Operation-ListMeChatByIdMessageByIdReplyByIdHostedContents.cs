// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeChatMessageReplyHostedContent;

internal class ListMeChatByIdMessageByIdReplyByIdHostedContentsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new MeChatIdMessageIdReplyId();
    public override Type NestedItemType() => typeof(ChatMessageHostedContentCollectionResponseModel);
    public override string? UriSuffix() => "/hostedContents";
}
