// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupTeamChannelSharedWithTeam;

internal class ListGroupByIdTeamChannelByIdSharedWithTeamsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new GroupIdTeamChannelId();
    public override Type NestedItemType() => typeof(SharedWithChannelTeamInfoCollectionResponseModel);
    public override string? UriSuffix() => "/sharedWithTeams";
}
