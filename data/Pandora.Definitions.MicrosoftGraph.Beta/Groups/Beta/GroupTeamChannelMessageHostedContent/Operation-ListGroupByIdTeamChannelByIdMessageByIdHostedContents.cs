// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupTeamChannelMessageHostedContent;

internal class ListGroupByIdTeamChannelByIdMessageByIdHostedContentsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new GroupIdTeamChannelIdMessageId();
    public override Type NestedItemType() => typeof(ChatMessageHostedContentCollectionResponseModel);
    public override string? UriSuffix() => "/hostedContents";
}
