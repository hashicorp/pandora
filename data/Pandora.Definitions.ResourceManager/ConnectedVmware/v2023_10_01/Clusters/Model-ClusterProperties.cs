using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2023_10_01.Clusters;


internal class ClusterPropertiesModel
{
    [JsonPropertyName("customResourceName")]
    public string? CustomResourceName { get; set; }

    [JsonPropertyName("datastoreIds")]
    public List<string>? DatastoreIds { get; set; }

    [JsonPropertyName("inventoryItemId")]
    public string? InventoryItemId { get; set; }

    [JsonPropertyName("moName")]
    public string? MoName { get; set; }

    [JsonPropertyName("moRefId")]
    public string? MoRefId { get; set; }

    [JsonPropertyName("networkIds")]
    public List<string>? NetworkIds { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("statuses")]
    public List<ResourceStatusModel>? Statuses { get; set; }

    [JsonPropertyName("totalCpuMHz")]
    public int? TotalCPUMHz { get; set; }

    [JsonPropertyName("totalMemoryGB")]
    public int? TotalMemoryGB { get; set; }

    [JsonPropertyName("usedCpuMHz")]
    public int? UsedCPUMHz { get; set; }

    [JsonPropertyName("usedMemoryGB")]
    public int? UsedMemoryGB { get; set; }

    [JsonPropertyName("uuid")]
    public string? Uuid { get; set; }

    [JsonPropertyName("vCenterId")]
    public string? VCenterId { get; set; }
}
