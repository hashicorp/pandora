// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.VMware.v2023_03_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-03-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Addons.Definition(),
        new Authorizations.Definition(),
        new CloudLinks.Definition(),
        new Cluster.Definition(),
        new Clusters.Definition(),
        new DataStores.Definition(),
        new GlobalReachConnections.Definition(),
        new HcxEnterpriseSites.Definition(),
        new Locations.Definition(),
        new PlacementPolicies.Definition(),
        new PrivateClouds.Definition(),
        new Scripts.Definition(),
        new VirtualMachines.Definition(),
        new WorkloadNetworks.Definition(),
        new Zone.Definition(),
    };
}
