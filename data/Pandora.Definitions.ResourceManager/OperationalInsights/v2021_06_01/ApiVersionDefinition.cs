// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2021_06_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-06-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Clusters.Definition(),
        new DeletedWorkspaces.Definition(),
        new Workspaces.Definition(),
    };
}
