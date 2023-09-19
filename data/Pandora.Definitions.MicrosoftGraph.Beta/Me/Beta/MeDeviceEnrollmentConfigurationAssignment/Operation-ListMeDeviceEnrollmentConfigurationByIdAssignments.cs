// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeDeviceEnrollmentConfigurationAssignment;

internal class ListMeDeviceEnrollmentConfigurationByIdAssignmentsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new MeDeviceEnrollmentConfigurationId();
    public override Type NestedItemType() => typeof(EnrollmentConfigurationAssignmentCollectionResponseModel);
    public override string? UriSuffix() => "/assignments";
}
