using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.VirtualMachineScaleSetVMs;


internal class VirtualMachineScaleSetPublicIPAddressConfigurationPropertiesModel
{
    [JsonPropertyName("deleteOption")]
    public DeleteOptionsConstant? DeleteOption { get; set; }

    [JsonPropertyName("dnsSettings")]
    public VirtualMachineScaleSetPublicIPAddressConfigurationDnsSettingsModel? DnsSettings { get; set; }

    [JsonPropertyName("ipTags")]
    public List<VirtualMachineScaleSetIPTagModel>? IPTags { get; set; }

    [JsonPropertyName("idleTimeoutInMinutes")]
    public int? IdleTimeoutInMinutes { get; set; }

    [JsonPropertyName("publicIPAddressVersion")]
    public IPVersionConstant? PublicIPAddressVersion { get; set; }

    [JsonPropertyName("publicIPPrefix")]
    public SubResourceModel? PublicIPPrefix { get; set; }
}
