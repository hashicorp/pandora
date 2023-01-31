using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Alerts;


internal class AlertPropertiesModel
{
    [JsonPropertyName("alertType")]
    public string? AlertType { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("appearedAtDateTime")]
    public DateTime? AppearedAtDateTime { get; set; }

    [JsonPropertyName("detailedInformation")]
    public Dictionary<string, string>? DetailedInformation { get; set; }

    [JsonPropertyName("errorDetails")]
    public AlertErrorDetailsModel? ErrorDetails { get; set; }

    [JsonPropertyName("recommendation")]
    public string? Recommendation { get; set; }

    [JsonPropertyName("severity")]
    public AlertSeverityConstant? Severity { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }
}
