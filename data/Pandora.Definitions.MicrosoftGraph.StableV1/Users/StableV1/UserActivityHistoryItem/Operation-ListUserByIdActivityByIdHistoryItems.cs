// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserActivityHistoryItem;

internal class ListUserByIdActivityByIdHistoryItemsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new UserIdActivityId();
    public override Type NestedItemType() => typeof(ActivityHistoryItemCollectionResponseModel);
    public override string? UriSuffix() => "/historyItems";
}
