using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2022_11_01.SIMs;


internal class EncryptedSimPropertiesFormatModel
{
    [JsonPropertyName("deviceType")]
    public string? DeviceType { get; set; }

    [JsonPropertyName("encryptedCredentials")]
    public string? EncryptedCredentials { get; set; }

    [JsonPropertyName("integratedCircuitCardIdentifier")]
    public string? IntegratedCircuitCardIdentifier { get; set; }

    [JsonPropertyName("internationalMobileSubscriberIdentity")]
    [Required]
    public string InternationalMobileSubscriberIdentity { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("simPolicy")]
    public SimPolicyResourceIdModel? SimPolicy { get; set; }

    [JsonPropertyName("simState")]
    public SimStateConstant? SimState { get; set; }

    [JsonPropertyName("siteProvisioningState")]
    public Dictionary<string, SiteProvisioningStateConstant>? SiteProvisioningState { get; set; }

    [MinItems(1)]
    [JsonPropertyName("staticIpConfiguration")]
    public List<SimStaticIPPropertiesModel>? StaticIPConfiguration { get; set; }

    [JsonPropertyName("vendorKeyFingerprint")]
    public string? VendorKeyFingerprint { get; set; }

    [JsonPropertyName("vendorName")]
    public string? VendorName { get; set; }
}
