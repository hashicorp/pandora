// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ElasticSan.v2023_01_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-01-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new ElasticSan.Definition(),
        new ElasticSanSkus.Definition(),
        new ElasticSans.Definition(),
        new PrivateEndpointConnections.Definition(),
        new PrivateLinkResources.Definition(),
        new Snapshots.Definition(),
        new VolumeGroups.Definition(),
        new Volumes.Definition(),
    };
}
