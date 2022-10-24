using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2022_10_01.Tables;


internal class TablePropertiesModel
{
    [JsonPropertyName("archiveRetentionInDays")]
    public int? ArchiveRetentionInDays { get; set; }

    [JsonPropertyName("lastPlanModifiedDate")]
    public string? LastPlanModifiedDate { get; set; }

    [JsonPropertyName("plan")]
    public TablePlanEnumConstant? Plan { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateEnumConstant? ProvisioningState { get; set; }

    [JsonPropertyName("restoredLogs")]
    public RestoredLogsModel? RestoredLogs { get; set; }

    [JsonPropertyName("resultStatistics")]
    public ResultStatisticsModel? ResultStatistics { get; set; }

    [JsonPropertyName("retentionInDays")]
    public int? RetentionInDays { get; set; }

    [JsonPropertyName("retentionInDaysAsDefault")]
    public RetentionInDaysAsDefaultConstant? RetentionInDaysAsDefault { get; set; }

    [JsonPropertyName("schema")]
    public SchemaModel? Schema { get; set; }

    [JsonPropertyName("searchResults")]
    public SearchResultsModel? SearchResults { get; set; }

    [JsonPropertyName("totalRetentionInDays")]
    public int? TotalRetentionInDays { get; set; }

    [JsonPropertyName("totalRetentionInDaysAsDefault")]
    public TotalRetentionInDaysAsDefaultConstant? TotalRetentionInDaysAsDefault { get; set; }
}
