// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.RoleManagement.StableV1.RoleManagementDirectoryResourceNamespaceResourceAction;

internal class ListRoleManagementDirectoryResourceNamespaceByIdResourceActionsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new RoleManagementDirectoryResourceNamespaceId();
    public override Type NestedItemType() => typeof(UnifiedRbacResourceActionCollectionResponseModel);
    public override string? UriSuffix() => "/resourceActions";
}
