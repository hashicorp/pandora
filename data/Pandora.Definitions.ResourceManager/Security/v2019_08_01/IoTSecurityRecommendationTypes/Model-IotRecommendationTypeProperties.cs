using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_08_01.IoTSecurityRecommendationTypes;


internal class IotRecommendationTypePropertiesModel
{
    [JsonPropertyName("control")]
    public string? Control { get; set; }

    [JsonPropertyName("dataSource")]
    public string? DataSource { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("productComponentName")]
    public string? ProductComponentName { get; set; }

    [JsonPropertyName("productName")]
    public string? ProductName { get; set; }

    [JsonPropertyName("recommendationDisplayName")]
    public string? RecommendationDisplayName { get; set; }

    [JsonPropertyName("remediationSteps")]
    public List<string>? RemediationSteps { get; set; }

    [JsonPropertyName("severity")]
    public RecommendationSeverityConstant? Severity { get; set; }

    [JsonPropertyName("vendorName")]
    public string? VendorName { get; set; }
}
