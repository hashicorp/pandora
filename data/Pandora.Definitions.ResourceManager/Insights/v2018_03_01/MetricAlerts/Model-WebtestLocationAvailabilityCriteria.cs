using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2018_03_01.MetricAlerts;

[ValueForType("Microsoft.Azure.Monitor.WebtestLocationAvailabilityCriteria")]
internal class WebtestLocationAvailabilityCriteriaModel : MetricAlertCriteriaModel
{
    [JsonPropertyName("componentId")]
    [Required]
    public string ComponentId { get; set; }

    [JsonPropertyName("failedLocationCount")]
    [Required]
    public float FailedLocationCount { get; set; }

    [JsonPropertyName("webTestId")]
    [Required]
    public string WebTestId { get; set; }
}
