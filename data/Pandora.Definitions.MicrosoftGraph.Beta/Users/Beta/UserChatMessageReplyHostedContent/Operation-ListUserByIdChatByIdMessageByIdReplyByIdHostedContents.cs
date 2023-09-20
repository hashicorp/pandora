// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserChatMessageReplyHostedContent;

internal class ListUserByIdChatByIdMessageByIdReplyByIdHostedContentsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new UserIdChatIdMessageIdReplyId();
    public override Type NestedItemType() => typeof(ChatMessageHostedContentCollectionResponseModel);
    public override string? UriSuffix() => "/hostedContents";
}
