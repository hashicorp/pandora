using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageCache.v2023_05_01.AmlFilesystems;


internal class AmlFilesystemSubnetInfoModel
{
    [JsonPropertyName("filesystemSubnet")]
    public string? FilesystemSubnet { get; set; }

    [JsonPropertyName("location")]
    public CustomTypes.Location? Location { get; set; }

    [JsonPropertyName("sku")]
    public SkuNameModel? Sku { get; set; }

    [JsonPropertyName("storageCapacityTiB")]
    public float? StorageCapacityTiB { get; set; }
}
