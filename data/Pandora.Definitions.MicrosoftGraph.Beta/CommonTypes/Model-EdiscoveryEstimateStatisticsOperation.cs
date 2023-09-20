// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class EdiscoveryEstimateStatisticsOperationModel
{
    [JsonPropertyName("action")]
    public EdiscoveryEstimateStatisticsOperationActionConstant? Action { get; set; }

    [JsonPropertyName("completedDateTime")]
    public DateTime? CompletedDateTime { get; set; }

    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("indexedItemCount")]
    public int? IndexedItemCount { get; set; }

    [JsonPropertyName("indexedItemsSize")]
    public int? IndexedItemsSize { get; set; }

    [JsonPropertyName("mailboxCount")]
    public int? MailboxCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("percentProgress")]
    public int? PercentProgress { get; set; }

    [JsonPropertyName("resultInfo")]
    public ResultInfoModel? ResultInfo { get; set; }

    [JsonPropertyName("siteCount")]
    public int? SiteCount { get; set; }

    [JsonPropertyName("sourceCollection")]
    public EdiscoverySourceCollectionModel? SourceCollection { get; set; }

    [JsonPropertyName("status")]
    public EdiscoveryEstimateStatisticsOperationStatusConstant? Status { get; set; }

    [JsonPropertyName("unindexedItemCount")]
    public int? UnindexedItemCount { get; set; }

    [JsonPropertyName("unindexedItemsSize")]
    public int? UnindexedItemsSize { get; set; }
}
