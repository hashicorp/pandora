using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationProtectedItems;


internal class InMageRcmNicDetailsModel
{
    [JsonPropertyName("isPrimaryNic")]
    public string? IsPrimaryNic { get; set; }

    [JsonPropertyName("isSelectedForFailover")]
    public string? IsSelectedForFailover { get; set; }

    [JsonPropertyName("nicId")]
    public string? NicId { get; set; }

    [JsonPropertyName("sourceIPAddress")]
    public string? SourceIPAddress { get; set; }

    [JsonPropertyName("sourceIPAddressType")]
    public EthernetAddressTypeConstant? SourceIPAddressType { get; set; }

    [JsonPropertyName("sourceNetworkId")]
    public string? SourceNetworkId { get; set; }

    [JsonPropertyName("sourceSubnetName")]
    public string? SourceSubnetName { get; set; }

    [JsonPropertyName("targetIPAddress")]
    public string? TargetIPAddress { get; set; }

    [JsonPropertyName("targetIPAddressType")]
    public EthernetAddressTypeConstant? TargetIPAddressType { get; set; }

    [JsonPropertyName("targetSubnetName")]
    public string? TargetSubnetName { get; set; }

    [JsonPropertyName("testIPAddress")]
    public string? TestIPAddress { get; set; }

    [JsonPropertyName("testIPAddressType")]
    public EthernetAddressTypeConstant? TestIPAddressType { get; set; }

    [JsonPropertyName("testSubnetName")]
    public string? TestSubnetName { get; set; }
}
