// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TermsAndConditionsAcceptanceStatusModel
{
    [JsonPropertyName("acceptedDateTime")]
    public DateTime? AcceptedDateTime { get; set; }

    [JsonPropertyName("acceptedVersion")]
    public int? AcceptedVersion { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("termsAndConditions")]
    public TermsAndConditionsModel? TermsAndConditions { get; set; }

    [JsonPropertyName("userDisplayName")]
    public string? UserDisplayName { get; set; }

    [JsonPropertyName("userPrincipalName")]
    public string? UserPrincipalName { get; set; }
}
