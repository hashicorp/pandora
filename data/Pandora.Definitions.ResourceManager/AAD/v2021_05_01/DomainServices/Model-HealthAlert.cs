using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AAD.v2021_05_01.DomainServices;


internal class HealthAlertModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("issue")]
    public string? Issue { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastDetected")]
    public DateTime? LastDetected { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("raised")]
    public DateTime? Raised { get; set; }

    [JsonPropertyName("resolutionUri")]
    public string? ResolutionUri { get; set; }

    [JsonPropertyName("severity")]
    public string? Severity { get; set; }
}
