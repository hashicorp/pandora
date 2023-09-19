// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class BrowserSharedCookieHistoryModel
{
    [JsonPropertyName("comment")]
    public string? Comment { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("hostOnly")]
    public bool? HostOnly { get; set; }

    [JsonPropertyName("hostOrDomain")]
    public string? HostOrDomain { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public IdentitySetModel? LastModifiedBy { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("path")]
    public string? Path { get; set; }

    [JsonPropertyName("publishedDateTime")]
    public DateTime? PublishedDateTime { get; set; }

    [JsonPropertyName("sourceEnvironment")]
    public BrowserSharedCookieHistorySourceEnvironmentConstant? SourceEnvironment { get; set; }
}
