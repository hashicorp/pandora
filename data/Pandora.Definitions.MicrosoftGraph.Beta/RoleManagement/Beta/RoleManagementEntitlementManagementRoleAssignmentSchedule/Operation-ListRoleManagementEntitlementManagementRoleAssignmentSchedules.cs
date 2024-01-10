// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementEntitlementManagementRoleAssignmentSchedule;

internal class ListRoleManagementEntitlementManagementRoleAssignmentSchedulesOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => null;
    public override Type NestedItemType() => typeof(UnifiedRoleAssignmentScheduleCollectionResponseModel);
    public override string? UriSuffix() => "/roleManagement/entitlementManagement/roleAssignmentSchedules";
}
