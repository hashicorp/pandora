// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-01-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AppServiceCertificateOrders.Definition(),
        new AppServiceEnvironments.Definition(),
        new AppServicePlans.Definition(),
        new CertificateOrdersDiagnostics.Definition(),
        new Certificates.Definition(),
        new ContainerApps.Definition(),
        new ContainerAppsRevisions.Definition(),
        new DeletedWebApps.Definition(),
        new Diagnostics.Definition(),
        new Domains.Definition(),
        new Global.Definition(),
        new KubeEnvironments.Definition(),
        new Provider.Definition(),
        new Recommendations.Definition(),
        new ResourceHealthMetadata.Definition(),
        new ResourceProviders.Definition(),
        new StaticSites.Definition(),
        new TopLevelDomains.Definition(),
        new WebApps.Definition(),
        new WorkflowRunActions.Definition(),
        new WorkflowRuns.Definition(),
        new WorkflowTriggerHistories.Definition(),
        new WorkflowTriggers.Definition(),
        new WorkflowVersions.Definition(),
        new Workflows.Definition(),
    };
}
