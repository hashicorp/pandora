// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Maintenance.v2023_04_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-04-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new ApplyUpdates.Definition(),
        new ConfigurationAssignments.Definition(),
        new MaintenanceConfigurations.Definition(),
        new PublicMaintenanceConfigurations.Definition(),
        new Updates.Definition(),
    };
}
