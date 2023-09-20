// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementDeviceManagementRoleAssignmentPrincipal;

internal class ListRoleManagementDeviceManagementRoleAssignmentByIdPrincipalsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new RoleManagementDeviceManagementRoleAssignmentId();
    public override Type NestedItemType() => typeof(DirectoryObjectCollectionResponseModel);
    public override string? UriSuffix() => "/principals";
}
