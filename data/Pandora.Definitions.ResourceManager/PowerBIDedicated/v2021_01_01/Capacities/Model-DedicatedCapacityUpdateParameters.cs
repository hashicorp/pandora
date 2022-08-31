using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.Capacities;


internal class DedicatedCapacityUpdateParametersModel
{
    [JsonPropertyName("properties")]
    public DedicatedCapacityMutablePropertiesModel? Properties { get; set; }

    [JsonPropertyName("sku")]
    public CapacitySkuModel? Sku { get; set; }

    [JsonPropertyName("tags")]
    public CustomTypes.Tags? Tags { get; set; }
}
