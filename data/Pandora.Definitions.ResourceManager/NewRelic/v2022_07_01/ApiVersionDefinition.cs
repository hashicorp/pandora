// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.NewRelic.v2022_07_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-07-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Accounts.Definition(),
        new Monitors.Definition(),
        new Organizations.Definition(),
        new Plan.Definition(),
        new TagRules.Definition(),
    };
}
