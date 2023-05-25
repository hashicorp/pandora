using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.LongTermRetentionBackups;


internal class CopyLongTermRetentionBackupParametersPropertiesModel
{
    [JsonPropertyName("targetBackupStorageRedundancy")]
    public BackupStorageRedundancyConstant? TargetBackupStorageRedundancy { get; set; }

    [JsonPropertyName("targetDatabaseName")]
    public string? TargetDatabaseName { get; set; }

    [JsonPropertyName("targetResourceGroup")]
    public string? TargetResourceGroup { get; set; }

    [JsonPropertyName("targetServerFullyQualifiedDomainName")]
    public string? TargetServerFullyQualifiedDomainName { get; set; }

    [JsonPropertyName("targetServerResourceId")]
    public string? TargetServerResourceId { get; set; }

    [JsonPropertyName("targetSubscriptionId")]
    public string? TargetSubscriptionId { get; set; }
}
