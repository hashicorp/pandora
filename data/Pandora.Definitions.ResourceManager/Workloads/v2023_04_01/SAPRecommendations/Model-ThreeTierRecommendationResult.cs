using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SAPRecommendations;

[ValueForType("ThreeTier")]
internal class ThreeTierRecommendationResultModel : SAPSizingRecommendationResultModel
{
    [JsonPropertyName("applicationServerInstanceCount")]
    public int? ApplicationServerInstanceCount { get; set; }

    [JsonPropertyName("applicationServerVmSku")]
    public string? ApplicationServerVMSku { get; set; }

    [JsonPropertyName("centralServerInstanceCount")]
    public int? CentralServerInstanceCount { get; set; }

    [JsonPropertyName("centralServerVmSku")]
    public string? CentralServerVMSku { get; set; }

    [JsonPropertyName("databaseInstanceCount")]
    public int? DatabaseInstanceCount { get; set; }

    [JsonPropertyName("dbVmSku")]
    public string? DbVMSku { get; set; }
}
