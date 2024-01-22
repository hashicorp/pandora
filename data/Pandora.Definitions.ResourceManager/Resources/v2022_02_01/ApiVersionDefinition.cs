// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Resources.v2022_02_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-02-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new TemplateSpecVersions.Definition(),
        new TemplateSpecs.Definition(),
    };
}
