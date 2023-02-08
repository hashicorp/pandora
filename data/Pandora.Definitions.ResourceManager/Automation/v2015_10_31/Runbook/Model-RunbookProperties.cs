using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2015_10_31.Runbook;


internal class RunbookPropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("creationTime")]
    public DateTime? CreationTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("draft")]
    public RunbookDraftModel? Draft { get; set; }

    [JsonPropertyName("jobCount")]
    public int? JobCount { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public string? LastModifiedBy { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModifiedTime")]
    public DateTime? LastModifiedTime { get; set; }

    [JsonPropertyName("logActivityTrace")]
    public int? LogActivityTrace { get; set; }

    [JsonPropertyName("logProgress")]
    public bool? LogProgress { get; set; }

    [JsonPropertyName("logVerbose")]
    public bool? LogVerbose { get; set; }

    [JsonPropertyName("outputTypes")]
    public List<string>? OutputTypes { get; set; }

    [JsonPropertyName("parameters")]
    public Dictionary<string, RunbookParameterModel>? Parameters { get; set; }

    [JsonPropertyName("provisioningState")]
    public RunbookProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publishContentLink")]
    public ContentLinkModel? PublishContentLink { get; set; }

    [JsonPropertyName("runbookType")]
    public RunbookTypeEnumConstant? RunbookType { get; set; }

    [JsonPropertyName("state")]
    public RunbookStateConstant? State { get; set; }
}
