using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2021_10_01.CapacityPools;


internal class PoolPropertiesModel
{
    [JsonPropertyName("coolAccess")]
    public bool? CoolAccess { get; set; }

    [JsonPropertyName("encryptionType")]
    public EncryptionTypeConstant? EncryptionType { get; set; }

    [JsonPropertyName("poolId")]
    public string? PoolId { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("qosType")]
    public QosTypeConstant? QosType { get; set; }

    [JsonPropertyName("serviceLevel")]
    [Required]
    public ServiceLevelConstant ServiceLevel { get; set; }

    [JsonPropertyName("size")]
    [Required]
    public int Size { get; set; }

    [JsonPropertyName("totalThroughputMibps")]
    public float? TotalThroughputMibps { get; set; }

    [JsonPropertyName("utilizedThroughputMibps")]
    public float? UtilizedThroughputMibps { get; set; }
}
