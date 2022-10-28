using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StoragePool.v2021_08_01.DiskPoolZones;


internal class DiskPoolZoneInfoModel
{
    [JsonPropertyName("additionalCapabilities")]
    public List<string>? AdditionalCapabilities { get; set; }

    [JsonPropertyName("availabilityZones")]
    public CustomTypes.Zones? AvailabilityZones { get; set; }

    [JsonPropertyName("sku")]
    public SkuModel? Sku { get; set; }
}
