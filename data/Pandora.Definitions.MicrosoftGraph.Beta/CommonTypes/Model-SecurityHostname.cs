// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityHostnameModel
{
    [JsonPropertyName("components")]
    public List<HostComponentModel>? Components { get; set; }

    [JsonPropertyName("cookies")]
    public List<HostCookieModel>? Cookies { get; set; }

    [JsonPropertyName("firstSeenDateTime")]
    public DateTime? FirstSeenDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastSeenDateTime")]
    public DateTime? LastSeenDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("passiveDns")]
    public List<PassiveDnsRecordModel>? PassiveDns { get; set; }

    [JsonPropertyName("passiveDnsReverse")]
    public List<PassiveDnsRecordModel>? PassiveDnsReverse { get; set; }

    [JsonPropertyName("registrant")]
    public string? Registrant { get; set; }

    [JsonPropertyName("registrar")]
    public string? Registrar { get; set; }

    [JsonPropertyName("reputation")]
    public HostReputationModel? Reputation { get; set; }

    [JsonPropertyName("trackers")]
    public List<HostTrackerModel>? Trackers { get; set; }
}
