// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupTeamPrimaryChannelMessageReply;

internal class ListGroupByIdTeamPrimaryChannelMessageByIdRepliesOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new GroupIdTeamPrimaryChannelMessageId();
    public override Type NestedItemType() => typeof(ChatMessageCollectionResponseModel);
    public override string? UriSuffix() => "/replies";
}
