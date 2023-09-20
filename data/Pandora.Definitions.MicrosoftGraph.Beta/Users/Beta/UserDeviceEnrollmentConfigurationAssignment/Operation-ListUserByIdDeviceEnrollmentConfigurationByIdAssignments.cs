// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserDeviceEnrollmentConfigurationAssignment;

internal class ListUserByIdDeviceEnrollmentConfigurationByIdAssignmentsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new UserIdDeviceEnrollmentConfigurationId();
    public override Type NestedItemType() => typeof(EnrollmentConfigurationAssignmentCollectionResponseModel);
    public override string? UriSuffix() => "/assignments";
}
