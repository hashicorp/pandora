// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.RoleManagement.StableV1.RoleManagementEntitlementManagementRoleDefinitionInheritsPermissionsFrom;

internal class ListRoleManagementEntitlementManagementRoleDefinitionByIdInheritsPermissionsFromsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new RoleManagementEntitlementManagementRoleDefinitionId();
    public override Type NestedItemType() => typeof(UnifiedRoleDefinitionCollectionResponseModel);
    public override string? UriSuffix() => "/inheritsPermissionsFrom";
}
