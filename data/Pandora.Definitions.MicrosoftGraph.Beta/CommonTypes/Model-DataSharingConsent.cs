// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DataSharingConsentModel
{
    [JsonPropertyName("grantDateTime")]
    public DateTime? GrantDateTime { get; set; }

    [JsonPropertyName("granted")]
    public bool? Granted { get; set; }

    [JsonPropertyName("grantedByUpn")]
    public string? GrantedByUpn { get; set; }

    [JsonPropertyName("grantedByUserId")]
    public string? GrantedByUserId { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("serviceDisplayName")]
    public string? ServiceDisplayName { get; set; }

    [JsonPropertyName("termsUrl")]
    public string? TermsUrl { get; set; }
}
