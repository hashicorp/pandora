// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Insights.v2018_03_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2018-03-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new ActionGroupsAPIs.Definition(),
        new MetricAlerts.Definition(),
        new MetricAlertsStatus.Definition(),
    };
}
