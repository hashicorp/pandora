// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class BrowserSharedCookieModel
{
    [JsonPropertyName("comment")]
    public string? Comment { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("deletedDateTime")]
    public DateTime? DeletedDateTime { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("history")]
    public List<BrowserSharedCookieHistoryModel>? History { get; set; }

    [JsonPropertyName("hostOnly")]
    public bool? HostOnly { get; set; }

    [JsonPropertyName("hostOrDomain")]
    public string? HostOrDomain { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public IdentitySetModel? LastModifiedBy { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("path")]
    public string? Path { get; set; }

    [JsonPropertyName("sourceEnvironment")]
    public BrowserSharedCookieSourceEnvironmentConstant? SourceEnvironment { get; set; }

    [JsonPropertyName("status")]
    public BrowserSharedCookieStatusConstant? Status { get; set; }
}
