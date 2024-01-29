// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.AzureActiveDirectory.v2017_04_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2017-04-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new DiagnosticSettings.Definition(),
        new DiagnosticSettingsCategories.Definition(),
    };
}
