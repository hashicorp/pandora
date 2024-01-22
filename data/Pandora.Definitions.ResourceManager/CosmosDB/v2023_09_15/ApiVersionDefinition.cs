// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2023_09_15;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-09-15";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new CosmosDB.Definition(),
        new DataTransfer.Definition(),
        new GraphAPICompute.Definition(),
        new ManagedCassandras.Definition(),
        new MaterializedViewsBuilder.Definition(),
        new Mongorbacs.Definition(),
        new NotebookWorkspacesResource.Definition(),
        new PrivateEndpointConnections.Definition(),
        new PrivateLinkResources.Definition(),
        new Rbacs.Definition(),
        new Restorables.Definition(),
        new Services.Definition(),
        new SqlDedicatedGateway.Definition(),
    };
}
