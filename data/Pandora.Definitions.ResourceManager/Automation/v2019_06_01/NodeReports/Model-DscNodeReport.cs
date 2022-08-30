using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.NodeReports;


internal class DscNodeReportModel
{
    [JsonPropertyName("configurationVersion")]
    public string? ConfigurationVersion { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endTime")]
    public DateTime? EndTime { get; set; }

    [JsonPropertyName("errors")]
    public List<DscReportErrorModel>? Errors { get; set; }

    [JsonPropertyName("hostName")]
    public string? HostName { get; set; }

    [JsonPropertyName("iPV4Addresses")]
    public List<string>? IPV4Addresses { get; set; }

    [JsonPropertyName("iPV6Addresses")]
    public List<string>? IPV6Addresses { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModifiedTime")]
    public DateTime? LastModifiedTime { get; set; }

    [JsonPropertyName("metaConfiguration")]
    public DscMetaConfigurationModel? MetaConfiguration { get; set; }

    [JsonPropertyName("numberOfResources")]
    public int? NumberOfResources { get; set; }

    [JsonPropertyName("rawErrors")]
    public string? RawErrors { get; set; }

    [JsonPropertyName("rebootRequested")]
    public string? RebootRequested { get; set; }

    [JsonPropertyName("refreshMode")]
    public string? RefreshMode { get; set; }

    [JsonPropertyName("reportFormatVersion")]
    public string? ReportFormatVersion { get; set; }

    [JsonPropertyName("reportId")]
    public string? ReportId { get; set; }

    [JsonPropertyName("resources")]
    public List<DscReportResourceModel>? Resources { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}
