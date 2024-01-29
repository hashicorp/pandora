// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2023_07_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-07-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new CacheRules.Definition(),
        new CredentialSets.Definition(),
        new Operation.Definition(),
        new PrivateEndpointConnections.Definition(),
        new Registries.Definition(),
        new Replications.Definition(),
        new ScopeMaps.Definition(),
        new Tokens.Definition(),
        new WebHooks.Definition(),
    };
}
