// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementEnterpriseAppRoleAssignmentApproval;

internal class ListRoleManagementEnterpriseAppByIdRoleAssignmentApprovalsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new RoleManagementEnterpriseAppId();
    public override Type NestedItemType() => typeof(ApprovalCollectionResponseModel);
    public override string? UriSuffix() => "/roleAssignmentApprovals";
}
