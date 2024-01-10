// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ParticipantInfoModel
{
    [JsonPropertyName("countryCode")]
    public string? CountryCode { get; set; }

    [JsonPropertyName("endpointType")]
    public ParticipantInfoEndpointTypeConstant? EndpointType { get; set; }

    [JsonPropertyName("identity")]
    public IdentitySetModel? Identity { get; set; }

    [JsonPropertyName("languageId")]
    public string? LanguageId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("participantId")]
    public string? ParticipantId { get; set; }

    [JsonPropertyName("region")]
    public string? Region { get; set; }
}
