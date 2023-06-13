using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.ServerOperations;


internal class ServerOperationPropertiesModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("errorCode")]
    public int? ErrorCode { get; set; }

    [JsonPropertyName("errorDescription")]
    public string? ErrorDescription { get; set; }

    [JsonPropertyName("errorSeverity")]
    public int? ErrorSeverity { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("estimatedCompletionTime")]
    public DateTime? EstimatedCompletionTime { get; set; }

    [JsonPropertyName("isCancellable")]
    public bool? IsCancellable { get; set; }

    [JsonPropertyName("isUserError")]
    public bool? IsUserError { get; set; }

    [JsonPropertyName("operation")]
    public string? Operation { get; set; }

    [JsonPropertyName("operationFriendlyName")]
    public string? OperationFriendlyName { get; set; }

    [JsonPropertyName("percentComplete")]
    public int? PercentComplete { get; set; }

    [JsonPropertyName("serverName")]
    public string? ServerName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; set; }

    [JsonPropertyName("state")]
    public ManagementOperationStateConstant? State { get; set; }
}
