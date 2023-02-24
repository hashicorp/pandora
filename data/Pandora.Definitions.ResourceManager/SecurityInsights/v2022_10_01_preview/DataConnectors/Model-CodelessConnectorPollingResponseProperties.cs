using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.DataConnectors;


internal class CodelessConnectorPollingResponsePropertiesModel
{
    [JsonPropertyName("eventsJsonPaths")]
    [Required]
    public List<string> EventsJsonPaths { get; set; }

    [JsonPropertyName("isGzipCompressed")]
    public bool? IsGzipCompressed { get; set; }

    [JsonPropertyName("successStatusJsonPath")]
    public string? SuccessStatusJsonPath { get; set; }

    [JsonPropertyName("successStatusValue")]
    public string? SuccessStatusValue { get; set; }
}
