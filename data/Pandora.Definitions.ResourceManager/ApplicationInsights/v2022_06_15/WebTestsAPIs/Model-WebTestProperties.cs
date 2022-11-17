using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2022_06_15.WebTestsAPIs;


internal class WebTestPropertiesModel
{
    [JsonPropertyName("Configuration")]
    public WebTestPropertiesConfigurationModel? Configuration { get; set; }

    [JsonPropertyName("Description")]
    public string? Description { get; set; }

    [JsonPropertyName("Enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("Frequency")]
    public int? Frequency { get; set; }

    [JsonPropertyName("Kind")]
    [Required]
    public WebTestKindConstant Kind { get; set; }

    [JsonPropertyName("Locations")]
    [Required]
    public List<WebTestGeolocationModel> Locations { get; set; }

    [JsonPropertyName("Name")]
    [Required]
    public string Name { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("Request")]
    public WebTestPropertiesRequestModel? Request { get; set; }

    [JsonPropertyName("RetryEnabled")]
    public bool? RetryEnabled { get; set; }

    [JsonPropertyName("SyntheticMonitorId")]
    [Required]
    public string SyntheticMonitorId { get; set; }

    [JsonPropertyName("Timeout")]
    public int? Timeout { get; set; }

    [JsonPropertyName("ValidationRules")]
    public WebTestPropertiesValidationRulesModel? ValidationRules { get; set; }
}
