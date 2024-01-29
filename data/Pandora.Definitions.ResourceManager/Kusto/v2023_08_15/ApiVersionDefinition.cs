// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Kusto.v2023_08_15;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-08-15";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AttachedDatabaseConfigurations.Definition(),
        new ClusterPrincipalAssignments.Definition(),
        new Clusters.Definition(),
        new DataConnections.Definition(),
        new DatabasePrincipalAssignments.Definition(),
        new Databases.Definition(),
        new Kusto.Definition(),
        new ManagedPrivateEndpoints.Definition(),
        new OutboundNetworkDependenciesEndpoints.Definition(),
        new PrivateEndpointConnections.Definition(),
        new PrivateLinkResources.Definition(),
        new SandboxCustomImages.Definition(),
        new Scripts.Definition(),
    };
}
