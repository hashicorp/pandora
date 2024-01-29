// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2023_05_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-05-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AvailableWorkloadProfiles.Definition(),
        new BillingMeters.Definition(),
        new Certificates.Definition(),
        new ConnectedEnvironments.Definition(),
        new ConnectedEnvironmentsStorages.Definition(),
        new ContainerApps.Definition(),
        new ContainerAppsAuthConfigs.Definition(),
        new ContainerAppsRevisionReplicas.Definition(),
        new ContainerAppsRevisions.Definition(),
        new ContainerAppsSourceControls.Definition(),
        new DaprComponents.Definition(),
        new Diagnostics.Definition(),
        new Jobs.Definition(),
        new ManagedCertificates.Definition(),
        new ManagedEnvironments.Definition(),
        new ManagedEnvironmentsStorages.Definition(),
    };
}
