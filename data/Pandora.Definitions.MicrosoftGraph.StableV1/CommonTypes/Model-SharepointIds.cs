// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SharepointIdsModel
{
    [JsonPropertyName("listId")]
    public string? ListId { get; set; }

    [JsonPropertyName("listItemId")]
    public string? ListItemId { get; set; }

    [JsonPropertyName("listItemUniqueId")]
    public string? ListItemUniqueId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("siteId")]
    public string? SiteId { get; set; }

    [JsonPropertyName("siteUrl")]
    public string? SiteUrl { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    [JsonPropertyName("webId")]
    public string? WebId { get; set; }
}
