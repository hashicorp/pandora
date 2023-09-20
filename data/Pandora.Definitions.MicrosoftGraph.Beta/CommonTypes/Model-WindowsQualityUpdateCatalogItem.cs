// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsQualityUpdateCatalogItemModel
{
    [JsonPropertyName("classification")]
    public WindowsQualityUpdateCatalogItemClassificationConstant? Classification { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("endOfSupportDate")]
    public DateTime? EndOfSupportDate { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isExpeditable")]
    public bool? IsExpeditable { get; set; }

    [JsonPropertyName("kbArticleId")]
    public string? KbArticleId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("releaseDateTime")]
    public DateTime? ReleaseDateTime { get; set; }
}
