using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.ServerSitesController;


internal class SitesPropertiesModel
{
    [JsonPropertyName("agentDetails")]
    public SiteAgentPropertiesModel? AgentDetails { get; set; }

    [JsonPropertyName("applianceName")]
    public string? ApplianceName { get; set; }

    [JsonPropertyName("discoverySolutionId")]
    public string? DiscoverySolutionId { get; set; }

    [JsonPropertyName("masterSiteId")]
    public string? MasterSiteId { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("serviceEndpoint")]
    public string? ServiceEndpoint { get; set; }

    [JsonPropertyName("servicePrincipalIdentityDetails")]
    public SiteSpnPropertiesModel? ServicePrincipalIdentityDetails { get; set; }
}
