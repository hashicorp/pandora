using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.QumuloStorage.v2022_10_12.FileSystems;


internal class FileSystemResourcePropertiesModel
{
    [JsonPropertyName("adminPassword")]
    [Required]
    public string AdminPassword { get; set; }

    [JsonPropertyName("availabilityZone")]
    public CustomTypes.Zone? AvailabilityZone { get; set; }

    [JsonPropertyName("clusterLoginUrl")]
    public string? ClusterLoginUrl { get; set; }

    [JsonPropertyName("delegatedSubnetId")]
    [Required]
    public string DelegatedSubnetId { get; set; }

    [JsonPropertyName("initialCapacity")]
    [Required]
    public int InitialCapacity { get; set; }

    [JsonPropertyName("marketplaceDetails")]
    [Required]
    public MarketplaceDetailsModel MarketplaceDetails { get; set; }

    [JsonPropertyName("privateIPs")]
    public List<string>? PrivateIPs { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("storageSku")]
    [Required]
    public StorageSkuConstant StorageSku { get; set; }

    [JsonPropertyName("userDetails")]
    [Required]
    public UserDetailsModel UserDetails { get; set; }
}
