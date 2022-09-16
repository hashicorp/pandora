using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.SqlPools;


internal class SqlPoolResourcePropertiesModel
{
    [JsonPropertyName("collation")]
    public string? Collation { get; set; }

    [JsonPropertyName("createMode")]
    public CreateModeConstant? CreateMode { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("creationDate")]
    public DateTime? CreationDate { get; set; }

    [JsonPropertyName("maxSizeBytes")]
    public int? MaxSizeBytes { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("recoverableDatabaseId")]
    public string? RecoverableDatabaseId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("restorePointInTime")]
    public DateTime? RestorePointInTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("sourceDatabaseDeletionDate")]
    public DateTime? SourceDatabaseDeletionDate { get; set; }

    [JsonPropertyName("sourceDatabaseId")]
    public string? SourceDatabaseId { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("storageAccountType")]
    public StorageAccountTypeConstant? StorageAccountType { get; set; }
}
