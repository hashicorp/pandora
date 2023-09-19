// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeJoinedTeamOperation;

internal class ListMeJoinedTeamByIdOperationsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new MeJoinedTeamId();
    public override Type NestedItemType() => typeof(TeamsAsyncOperationCollectionResponseModel);
    public override string? UriSuffix() => "/operations";
}
