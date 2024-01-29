// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2023_04_15_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-04-15-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Capabilities.Definition(),
        new CapabilityTypes.Definition(),
        new Experiments.Definition(),
        new TargetTypes.Definition(),
        new Targets.Definition(),
    };
}
