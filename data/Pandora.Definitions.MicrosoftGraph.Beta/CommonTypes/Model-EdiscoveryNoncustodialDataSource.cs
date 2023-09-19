// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class EdiscoveryNoncustodialDataSourceModel
{
    [JsonPropertyName("applyHoldToSource")]
    public bool? ApplyHoldToSource { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("dataSource")]
    public EdiscoveryDataSourceModel? DataSource { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("holdStatus")]
    public EdiscoveryNoncustodialDataSourceHoldStatusConstant? HoldStatus { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastIndexOperation")]
    public EdiscoveryCaseIndexOperationModel? LastIndexOperation { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("releasedDateTime")]
    public DateTime? ReleasedDateTime { get; set; }

    [JsonPropertyName("status")]
    public EdiscoveryNoncustodialDataSourceStatusConstant? Status { get; set; }
}
