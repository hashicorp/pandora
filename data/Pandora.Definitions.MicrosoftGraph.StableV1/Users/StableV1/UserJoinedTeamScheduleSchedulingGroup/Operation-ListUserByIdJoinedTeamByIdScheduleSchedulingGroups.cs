// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserJoinedTeamScheduleSchedulingGroup;

internal class ListUserByIdJoinedTeamByIdScheduleSchedulingGroupsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new UserIdJoinedTeamId();
    public override Type NestedItemType() => typeof(SchedulingGroupCollectionResponseModel);
    public override string? UriSuffix() => "/schedule/schedulingGroups";
}
