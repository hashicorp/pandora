// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityEdiscoveryEstimateOperationModel
{
    [JsonPropertyName("action")]
    public CaseActionConstant? Action { get; set; }

    [JsonPropertyName("completedDateTime")]
    public DateTime? CompletedDateTime { get; set; }

    [JsonPropertyName("createdBy")]
    public IdentitySetModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("indexedItemCount")]
    public long? IndexedItemCount { get; set; }

    [JsonPropertyName("indexedItemsSize")]
    public long? IndexedItemsSize { get; set; }

    [JsonPropertyName("mailboxCount")]
    public int? MailboxCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("percentProgress")]
    public int? PercentProgress { get; set; }

    [JsonPropertyName("resultInfo")]
    public ResultInfoModel? ResultInfo { get; set; }

    [JsonPropertyName("search")]
    public EdiscoverySearchModel? Search { get; set; }

    [JsonPropertyName("siteCount")]
    public int? SiteCount { get; set; }

    [JsonPropertyName("status")]
    public CaseOperationStatusConstant? Status { get; set; }

    [JsonPropertyName("unindexedItemCount")]
    public long? UnindexedItemCount { get; set; }

    [JsonPropertyName("unindexedItemsSize")]
    public long? UnindexedItemsSize { get; set; }
}
