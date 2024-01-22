// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DevCenter.v2023_04_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-04-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AttachedNetworkConnections.Definition(),
        new Catalogs.Definition(),
        new CheckNameAvailability.Definition(),
        new DevBoxDefinitions.Definition(),
        new DevCenters.Definition(),
        new EnvironmentTypes.Definition(),
        new Galleries.Definition(),
        new ImageVersions.Definition(),
        new Images.Definition(),
        new NetworkConnection.Definition(),
        new NetworkConnections.Definition(),
        new Pools.Definition(),
        new Projects.Definition(),
        new SKUs.Definition(),
        new Schedules.Definition(),
        new Usages.Definition(),
    };
}
