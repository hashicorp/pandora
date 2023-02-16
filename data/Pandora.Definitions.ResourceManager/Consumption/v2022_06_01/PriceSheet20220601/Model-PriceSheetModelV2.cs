using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2022_06_01.PriceSheet20220601;


internal class PriceSheetModelV2Model
{
    [JsonPropertyName("download")]
    public MeterDetailsV2Model? Download { get; set; }

    [JsonPropertyName("nextLink")]
    public string? NextLink { get; set; }

    [JsonPropertyName("pricesheets")]
    public List<PriceSheetPropertiesV2Model>? Pricesheets { get; set; }
}
