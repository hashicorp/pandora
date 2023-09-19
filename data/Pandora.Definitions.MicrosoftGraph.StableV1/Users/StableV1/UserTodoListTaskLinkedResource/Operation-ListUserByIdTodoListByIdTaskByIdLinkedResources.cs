// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserTodoListTaskLinkedResource;

internal class ListUserByIdTodoListByIdTaskByIdLinkedResourcesOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new UserIdTodoListIdTaskId();
    public override Type NestedItemType() => typeof(LinkedResourceCollectionResponseModel);
    public override string? UriSuffix() => "/linkedResources";
}
