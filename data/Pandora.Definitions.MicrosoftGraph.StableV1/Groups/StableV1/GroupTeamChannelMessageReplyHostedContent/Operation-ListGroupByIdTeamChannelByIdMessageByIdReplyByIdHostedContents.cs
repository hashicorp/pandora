// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupTeamChannelMessageReplyHostedContent;

internal class ListGroupByIdTeamChannelByIdMessageByIdReplyByIdHostedContentsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new GroupIdTeamChannelIdMessageIdReplyId();
    public override Type NestedItemType() => typeof(ChatMessageHostedContentCollectionResponseModel);
    public override string? UriSuffix() => "/hostedContents";
}
