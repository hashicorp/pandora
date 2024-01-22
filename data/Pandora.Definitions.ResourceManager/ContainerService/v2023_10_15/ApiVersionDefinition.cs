// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_10_15;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-10-15";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new FleetMembers.Definition(),
        new FleetUpdateStrategies.Definition(),
        new Fleets.Definition(),
        new UpdateRuns.Definition(),
    };
}
