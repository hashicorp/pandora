using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Portal.v2019_01_01_preview.TenantConfiguration;

internal class ConfigurationId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/providers/Microsoft.Portal/tenantConfigurations/{configurationName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftPortal", "Microsoft.Portal"),
        ResourceIDSegment.Static("staticTenantConfigurations", "tenantConfigurations"),
        ResourceIDSegment.Constant("configurationName", typeof(ConfigurationNameConstant)),
    };
}
