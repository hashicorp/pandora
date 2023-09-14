using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.WebAppSitesController;


internal class WebAppSitePropertiesModel
{
    [JsonPropertyName("discoveryScenario")]
    public WebAppSitePropertiesDiscoveryScenarioConstant? DiscoveryScenario { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("serviceEndpoint")]
    public string? ServiceEndpoint { get; set; }

    [JsonPropertyName("siteAppliancePropertiesCollection")]
    public List<SiteAppliancePropertiesModel>? SiteAppliancePropertiesCollection { get; set; }
}
