// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.RoleManagement.StableV1.RoleManagementEntitlementManagementResourceNamespaceResourceAction;

internal class ListRoleManagementEntitlementManagementResourceNamespaceByIdResourceActionsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new RoleManagementEntitlementManagementResourceNamespaceId();
    public override Type NestedItemType() => typeof(UnifiedRbacResourceActionCollectionResponseModel);
    public override string? UriSuffix() => "/resourceActions";
}
