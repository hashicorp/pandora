using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.LongTermRetentionBackups;


internal class LongTermRetentionOperationResultPropertiesModel
{
    [JsonPropertyName("fromBackupResourceId")]
    public string? FromBackupResourceId { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("operationType")]
    public string? OperationType { get; set; }

    [JsonPropertyName("requestId")]
    public string? RequestId { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("targetBackupStorageRedundancy")]
    public BackupStorageRedundancyConstant? TargetBackupStorageRedundancy { get; set; }

    [JsonPropertyName("toBackupResourceId")]
    public string? ToBackupResourceId { get; set; }
}
