using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2022_01_10_preview.InventoryItems;


internal abstract class InventoryItemPropertiesModel
{
    [JsonPropertyName("inventoryType")]
    [ProvidesTypeHint]
    [Required]
    public InventoryTypeConstant InventoryType { get; set; }

    [JsonPropertyName("managedResourceId")]
    public string? ManagedResourceId { get; set; }

    [JsonPropertyName("moName")]
    public string? MoName { get; set; }

    [JsonPropertyName("moRefId")]
    public string? MoRefId { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }
}
