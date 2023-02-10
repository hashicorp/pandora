using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_11_15.ManagedCassandras;


internal class DataCenterResourcePropertiesModel
{
    [JsonPropertyName("availabilityZone")]
    public bool? AvailabilityZone { get; set; }

    [JsonPropertyName("backupStorageCustomerKeyUri")]
    public string? BackupStorageCustomerKeyUri { get; set; }

    [JsonPropertyName("base64EncodedCassandraYamlFragment")]
    public string? Base64EncodedCassandraYamlFragment { get; set; }

    [JsonPropertyName("dataCenterLocation")]
    public string? DataCenterLocation { get; set; }

    [JsonPropertyName("delegatedSubnetId")]
    public string? DelegatedSubnetId { get; set; }

    [JsonPropertyName("diskCapacity")]
    public int? DiskCapacity { get; set; }

    [JsonPropertyName("diskSku")]
    public string? DiskSku { get; set; }

    [JsonPropertyName("managedDiskCustomerKeyUri")]
    public string? ManagedDiskCustomerKeyUri { get; set; }

    [JsonPropertyName("nodeCount")]
    public int? NodeCount { get; set; }

    [JsonPropertyName("provisioningState")]
    public ManagedCassandraProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("seedNodes")]
    public List<SeedNodeModel>? SeedNodes { get; set; }

    [JsonPropertyName("sku")]
    public string? Sku { get; set; }
}
