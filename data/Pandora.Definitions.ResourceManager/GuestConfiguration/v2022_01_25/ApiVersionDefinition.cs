// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.GuestConfiguration.v2022_01_25;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-01-25";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new GuestConfigurationAssignmentHCRPReports.Definition(),
        new GuestConfigurationAssignmentReports.Definition(),
        new GuestConfigurationAssignments.Definition(),
        new GuestConfigurationConnectedVMwarevSphereAssignments.Definition(),
        new GuestConfigurationConnectedVMwarevSphereAssignmentsReports.Definition(),
        new GuestConfigurationHCRPAssignments.Definition(),
    };
}
