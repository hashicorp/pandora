// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class EdiscoveryCustodianModel
{
    [JsonPropertyName("acknowledgedDateTime")]
    public DateTime? AcknowledgedDateTime { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("holdStatus")]
    public DataSourceHoldStatusConstant? HoldStatus { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastIndexOperation")]
    public EdiscoveryIndexOperationModel? LastIndexOperation { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("releasedDateTime")]
    public DateTime? ReleasedDateTime { get; set; }

    [JsonPropertyName("siteSources")]
    public List<SiteSourceModel>? SiteSources { get; set; }

    [JsonPropertyName("status")]
    public DataSourceContainerStatusConstant? Status { get; set; }

    [JsonPropertyName("unifiedGroupSources")]
    public List<UnifiedGroupSourceModel>? UnifiedGroupSources { get; set; }

    [JsonPropertyName("userSources")]
    public List<UserSourceModel>? UserSources { get; set; }
}
