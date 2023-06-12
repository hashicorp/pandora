using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceLinker.v2022_05_01.Links;


internal class ValidateResultModel
{
    [JsonPropertyName("authType")]
    public AuthTypeConstant? AuthType { get; set; }

    [JsonPropertyName("isConnectionAvailable")]
    public bool? IsConnectionAvailable { get; set; }

    [JsonPropertyName("linkerName")]
    public string? LinkerName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("reportEndTimeUtc")]
    public DateTime? ReportEndTimeUtc { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("reportStartTimeUtc")]
    public DateTime? ReportStartTimeUtc { get; set; }

    [JsonPropertyName("sourceId")]
    public string? SourceId { get; set; }

    [JsonPropertyName("targetId")]
    public string? TargetId { get; set; }

    [JsonPropertyName("validationDetail")]
    public List<ValidationResultItemModel>? ValidationDetail { get; set; }
}
