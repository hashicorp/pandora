// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserJoinedTeamScheduleTimesOff;

internal class ListUserByIdJoinedTeamByIdScheduleTimesOffsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new UserIdJoinedTeamId();
    public override Type NestedItemType() => typeof(TimeOffCollectionResponseModel);
    public override string? UriSuffix() => "/schedule/timesOff";
}
