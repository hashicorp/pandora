using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2022_08_29.Firewalls;


internal class FirewallDeploymentPropertiesModel
{
    [JsonPropertyName("associatedRulestack")]
    public RulestackDetailsModel? AssociatedRulestack { get; set; }

    [JsonPropertyName("dnsSettings")]
    [Required]
    public DNSSettingsModel DnsSettings { get; set; }

    [JsonPropertyName("frontEndSettings")]
    public List<FrontendSettingModel>? FrontEndSettings { get; set; }

    [JsonPropertyName("isPanoramaManaged")]
    public BooleanEnumConstant? IsPanoramaManaged { get; set; }

    [JsonPropertyName("marketplaceDetails")]
    [Required]
    public MarketplaceDetailsModel MarketplaceDetails { get; set; }

    [JsonPropertyName("networkProfile")]
    [Required]
    public NetworkProfileModel NetworkProfile { get; set; }

    [JsonPropertyName("panEtag")]
    public string? PanEtag { get; set; }

    [JsonPropertyName("panoramaConfig")]
    public PanoramaConfigModel? PanoramaConfig { get; set; }

    [JsonPropertyName("planData")]
    [Required]
    public PlanDataModel PlanData { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }
}
