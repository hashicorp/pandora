// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ServiceNetworking.v2023_05_01_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-05-01-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AssociationsInterface.Definition(),
        new FrontendsInterface.Definition(),
        new TrafficControllerInterface.Definition(),
    };
}
