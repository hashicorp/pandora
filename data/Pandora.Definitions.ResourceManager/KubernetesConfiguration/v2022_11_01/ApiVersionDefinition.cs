// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2022_11_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-11-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new ClusterExtensions.Definition(),
        new Extensions.Definition(),
        new Flux.Definition(),
        new FluxConfiguration.Definition(),
        new OperationsInACluster.Definition(),
        new SourceControlConfiguration.Definition(),
    };
}
