using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.ManagedDatabaseMoveOperations;


internal class ManagedDatabaseMoveOperationResultPropertiesModel
{
    [JsonPropertyName("errorCode")]
    public int? ErrorCode { get; set; }

    [JsonPropertyName("errorDescription")]
    public string? ErrorDescription { get; set; }

    [JsonPropertyName("errorSeverity")]
    public int? ErrorSeverity { get; set; }

    [JsonPropertyName("isCancellable")]
    public bool? IsCancellable { get; set; }

    [JsonPropertyName("isUserError")]
    public bool? IsUserError { get; set; }

    [JsonPropertyName("operation")]
    public string? Operation { get; set; }

    [JsonPropertyName("operationFriendlyName")]
    public string? OperationFriendlyName { get; set; }

    [JsonPropertyName("operationMode")]
    public MoveOperationModeConstant? OperationMode { get; set; }

    [JsonPropertyName("sourceDatabaseName")]
    public string? SourceDatabaseName { get; set; }

    [JsonPropertyName("sourceManagedInstanceId")]
    public string? SourceManagedInstanceId { get; set; }

    [JsonPropertyName("sourceManagedInstanceName")]
    public string? SourceManagedInstanceName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; set; }

    [JsonPropertyName("state")]
    public ManagementOperationStateConstant? State { get; set; }

    [JsonPropertyName("targetDatabaseName")]
    public string? TargetDatabaseName { get; set; }

    [JsonPropertyName("targetManagedInstanceId")]
    public string? TargetManagedInstanceId { get; set; }

    [JsonPropertyName("targetManagedInstanceName")]
    public string? TargetManagedInstanceName { get; set; }
}
