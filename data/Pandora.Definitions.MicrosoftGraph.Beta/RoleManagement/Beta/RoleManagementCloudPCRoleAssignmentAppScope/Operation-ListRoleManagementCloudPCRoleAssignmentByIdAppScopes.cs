// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementCloudPCRoleAssignmentAppScope;

internal class ListRoleManagementCloudPCRoleAssignmentByIdAppScopesOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new RoleManagementCloudPCRoleAssignmentId();
    public override Type NestedItemType() => typeof(AppScopeCollectionResponseModel);
    public override string? UriSuffix() => "/appScopes";
}
