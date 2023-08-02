using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2023_01_01.AccountMigrations;


internal class StorageAccountMigrationPropertiesModel
{
    [JsonPropertyName("migrationFailedDetailedReason")]
    public string? MigrationFailedDetailedReason { get; set; }

    [JsonPropertyName("migrationFailedReason")]
    public string? MigrationFailedReason { get; set; }

    [JsonPropertyName("migrationStatus")]
    public MigrationStatusConstant? MigrationStatus { get; set; }

    [JsonPropertyName("targetSkuName")]
    [Required]
    public SkuNameConstant TargetSkuName { get; set; }
}
