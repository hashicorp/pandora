// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserChatMessageReply;

internal class ListUserByIdChatByIdMessageByIdRepliesOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new UserIdChatIdMessageId();
    public override Type NestedItemType() => typeof(ChatMessageCollectionResponseModel);
    public override string? UriSuffix() => "/replies";
}
