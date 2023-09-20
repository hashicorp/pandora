// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ConversationThreadModel
{
    [JsonPropertyName("ccRecipients")]
    public List<RecipientModel>? CcRecipients { get; set; }

    [JsonPropertyName("hasAttachments")]
    public bool? HasAttachments { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isLocked")]
    public bool? IsLocked { get; set; }

    [JsonPropertyName("lastDeliveredDateTime")]
    public DateTime? LastDeliveredDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("posts")]
    public List<PostModel>? Posts { get; set; }

    [JsonPropertyName("preview")]
    public string? Preview { get; set; }

    [JsonPropertyName("toRecipients")]
    public List<RecipientModel>? ToRecipients { get; set; }

    [JsonPropertyName("topic")]
    public string? Topic { get; set; }

    [JsonPropertyName("uniqueSenders")]
    public List<string>? UniqueSenders { get; set; }
}
