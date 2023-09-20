// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeTodoListTaskChecklistItem;

internal class ListMeTodoListByIdTaskByIdChecklistItemsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new MeTodoListIdTaskId();
    public override Type NestedItemType() => typeof(ChecklistItemCollectionResponseModel);
    public override string? UriSuffix() => "/checklistItems";
}
