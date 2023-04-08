using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HDInsight.v2018_06_01_preview.Regions;


internal class RegionalQuotaCapabilityModel
{
    [JsonPropertyName("cores_available")]
    public int? CoresAvailable { get; set; }

    [JsonPropertyName("cores_used")]
    public int? CoresUsed { get; set; }

    [JsonPropertyName("region_name")]
    public string? RegionName { get; set; }
}
