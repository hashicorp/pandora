// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Security.v2019_01_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2019-01-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AdvancedThreatProtection.Definition(),
        new Alerts.Definition(),
        new Settings.Definition(),
    };
}
