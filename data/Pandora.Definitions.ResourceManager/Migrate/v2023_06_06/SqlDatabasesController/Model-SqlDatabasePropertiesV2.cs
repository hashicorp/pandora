using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.SqlDatabasesController;


internal class SqlDatabasePropertiesV2Model
{
    [JsonPropertyName("compatibilityLevel")]
    public string? CompatibilityLevel { get; set; }

    [JsonPropertyName("createdTimestamp")]
    public string? CreatedTimestamp { get; set; }

    [JsonPropertyName("databaseName")]
    public string? DatabaseName { get; set; }

    [JsonPropertyName("errors")]
    public List<ErrorsModel>? Errors { get; set; }

    [JsonPropertyName("fileMetadataList")]
    public List<FileMetaDataModel>? FileMetadataList { get; set; }

    [JsonPropertyName("hostname")]
    public string? Hostname { get; set; }

    [JsonPropertyName("isDatabaseHighlyAvailable")]
    public bool? IsDatabaseHighlyAvailable { get; set; }

    [JsonPropertyName("isDeleted")]
    public bool? IsDeleted { get; set; }

    [JsonPropertyName("parentReplicaOverview")]
    public SqlAvailabilityReplicaOverviewModel? ParentReplicaOverview { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("sizeMb")]
    public float? SizeMb { get; set; }

    [JsonPropertyName("sqlServerArmId")]
    public string? SqlServerArmId { get; set; }

    [JsonPropertyName("sqlServerName")]
    public string? SqlServerName { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("updatedTimestamp")]
    public string? UpdatedTimestamp { get; set; }
}
