using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.NetworkVirtualAppliances;


internal class NetworkVirtualAppliancePropertiesFormatModel
{
    [JsonPropertyName("addressPrefix")]
    public string? AddressPrefix { get; set; }

    [JsonPropertyName("bootStrapConfigurationBlobs")]
    public List<string>? BootStrapConfigurationBlobs { get; set; }

    [JsonPropertyName("cloudInitConfiguration")]
    public string? CloudInitConfiguration { get; set; }

    [JsonPropertyName("cloudInitConfigurationBlobs")]
    public List<string>? CloudInitConfigurationBlobs { get; set; }

    [JsonPropertyName("inboundSecurityRules")]
    public List<SubResourceModel>? InboundSecurityRules { get; set; }

    [JsonPropertyName("nvaSku")]
    public VirtualApplianceSkuPropertiesModel? NvaSku { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("sshPublicKey")]
    public string? SshPublicKey { get; set; }

    [JsonPropertyName("virtualApplianceAsn")]
    public int? VirtualApplianceAsn { get; set; }

    [JsonPropertyName("virtualApplianceNics")]
    public List<VirtualApplianceNicPropertiesModel>? VirtualApplianceNics { get; set; }

    [JsonPropertyName("virtualApplianceSites")]
    public List<SubResourceModel>? VirtualApplianceSites { get; set; }

    [JsonPropertyName("virtualHub")]
    public SubResourceModel? VirtualHub { get; set; }
}
