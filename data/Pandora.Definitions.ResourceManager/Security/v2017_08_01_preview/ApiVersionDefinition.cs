// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Security.v2017_08_01_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2017-08-01-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AdvancedThreatProtection.Definition(),
        new AutoProvisioningSettings.Definition(),
        new Compliances.Definition(),
        new DeviceSecurityGroups.Definition(),
        new InformationProtectionPolicies.Definition(),
        new IoTSecuritySolutionsAnalytics.Definition(),
        new IotSecuritySolutions.Definition(),
        new Pricings.Definition(),
        new SecurityContacts.Definition(),
        new Settings.Definition(),
        new WorkspaceSettings.Definition(),
    };
}
