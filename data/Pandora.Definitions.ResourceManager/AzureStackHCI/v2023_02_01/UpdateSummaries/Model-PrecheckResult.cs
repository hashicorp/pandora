using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2023_02_01.UpdateSummaries;


internal class PrecheckResultModel
{
    [JsonPropertyName("additionalData")]
    public string? AdditionalData { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("healthCheckSource")]
    public string? HealthCheckSource { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("remediation")]
    public string? Remediation { get; set; }

    [JsonPropertyName("severity")]
    public SeverityConstant? Severity { get; set; }

    [JsonPropertyName("status")]
    public StatusConstant? Status { get; set; }

    [JsonPropertyName("tags")]
    public PrecheckResultTagsModel? Tags { get; set; }

    [JsonPropertyName("targetResourceID")]
    public string? TargetResourceID { get; set; }

    [JsonPropertyName("targetResourceName")]
    public string? TargetResourceName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("timestamp")]
    public DateTime? Timestamp { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }
}
