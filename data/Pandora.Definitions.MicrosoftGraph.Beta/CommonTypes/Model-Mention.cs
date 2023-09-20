// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MentionModel
{
    [JsonPropertyName("application")]
    public string? Application { get; set; }

    [JsonPropertyName("clientReference")]
    public string? ClientReference { get; set; }

    [JsonPropertyName("createdBy")]
    public EmailAddressModel? CreatedBy { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("deepLink")]
    public string? DeepLink { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("mentionText")]
    public string? MentionText { get; set; }

    [JsonPropertyName("mentioned")]
    public EmailAddressModel? Mentioned { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("serverCreatedDateTime")]
    public DateTime? ServerCreatedDateTime { get; set; }
}
