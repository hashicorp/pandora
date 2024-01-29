// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2020-01-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AdaptiveNetworkHardenings.Definition(),
        new Alerts.Definition(),
        new AllowedConnections.Definition(),
        new ApplicationWhitelistings.Definition(),
        new Assessments.Definition(),
        new AssessmentsMetadata.Definition(),
        new DiscoveredSecuritySolutions.Definition(),
        new ExternalSecuritySolutions.Definition(),
        new JitNetworkAccessPolicies.Definition(),
        new SecureScore.Definition(),
        new SecureScoreControlDefinitions.Definition(),
        new SecureScoreControls.Definition(),
        new SecuritySolutions.Definition(),
        new SecuritySolutionsReferenceData.Definition(),
        new ServerVulnerabilityAssessment.Definition(),
        new ServerVulnerabilityAssessments.Definition(),
        new Topology.Definition(),
    };
}
