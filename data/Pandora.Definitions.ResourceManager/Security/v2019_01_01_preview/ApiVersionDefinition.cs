// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Security.v2019_01_01_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2019-01-01-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AlertsSuppressionRules.Definition(),
        new Assessments.Definition(),
        new AssessmentsMetadata.Definition(),
        new Automations.Definition(),
        new RegulatoryCompliance.Definition(),
        new SubAssessments.Definition(),
    };
}
