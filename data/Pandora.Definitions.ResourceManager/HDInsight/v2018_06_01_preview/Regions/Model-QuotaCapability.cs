using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HDInsight.v2018_06_01_preview.Regions;


internal class QuotaCapabilityModel
{
    [JsonPropertyName("cores_used")]
    public int? CoresUsed { get; set; }

    [JsonPropertyName("max_cores_allowed")]
    public int? MaxCoresAllowed { get; set; }

    [JsonPropertyName("regionalQuotas")]
    public List<RegionalQuotaCapabilityModel>? RegionalQuotas { get; set; }
}
