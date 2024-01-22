// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.HybridCompute.v2022_12_27;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-12-27";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Extensions.Definition(),
        new MachineExtensions.Definition(),
        new MachineExtensionsUpgrade.Definition(),
        new MachineNetworkProfile.Definition(),
        new Machines.Definition(),
        new PrivateEndpointConnections.Definition(),
        new PrivateLinkResources.Definition(),
        new PrivateLinkScopes.Definition(),
    };
}
