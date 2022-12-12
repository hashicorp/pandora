using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2022_11_01.AttachedDataNetworks;


internal class AttachedDataNetworkPropertiesFormatModel
{
    [JsonPropertyName("dnsAddresses")]
    [Required]
    public List<string> DnsAddresses { get; set; }

    [JsonPropertyName("naptConfiguration")]
    public NaptConfigurationModel? NaptConfiguration { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [MinItems(1)]
    [JsonPropertyName("userEquipmentAddressPoolPrefix")]
    public List<string>? UserEquipmentAddressPoolPrefix { get; set; }

    [MinItems(1)]
    [JsonPropertyName("userEquipmentStaticAddressPoolPrefix")]
    public List<string>? UserEquipmentStaticAddressPoolPrefix { get; set; }

    [JsonPropertyName("userPlaneDataInterface")]
    [Required]
    public InterfacePropertiesModel UserPlaneDataInterface { get; set; }
}
