using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.NodeReports;


internal class DscReportResourceModel
{
    [JsonPropertyName("dependsOn")]
    public List<DscReportResourceNavigationModel>? DependsOn { get; set; }

    [JsonPropertyName("durationInSeconds")]
    public float? DurationInSeconds { get; set; }

    [JsonPropertyName("error")]
    public string? Error { get; set; }

    [JsonPropertyName("moduleName")]
    public string? ModuleName { get; set; }

    [JsonPropertyName("moduleVersion")]
    public string? ModuleVersion { get; set; }

    [JsonPropertyName("resourceId")]
    public string? ResourceId { get; set; }

    [JsonPropertyName("resourceName")]
    public string? ResourceName { get; set; }

    [JsonPropertyName("sourceInfo")]
    public string? SourceInfo { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startDate")]
    public DateTime? StartDate { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
