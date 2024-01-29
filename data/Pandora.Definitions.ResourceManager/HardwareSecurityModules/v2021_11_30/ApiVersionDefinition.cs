// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.HardwareSecurityModules.v2021_11_30;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-11-30";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new DedicatedHsms.Definition(),
    };
}
