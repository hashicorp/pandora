// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityWhoisHistoryRecordModel
{
    [JsonPropertyName("abuse")]
    public SecurityWhoisContactModel? Abuse { get; set; }

    [JsonPropertyName("admin")]
    public SecurityWhoisContactModel? Admin { get; set; }

    [JsonPropertyName("billing")]
    public SecurityWhoisContactModel? Billing { get; set; }

    [JsonPropertyName("domainStatus")]
    public string? DomainStatus { get; set; }

    [JsonPropertyName("expirationDateTime")]
    public DateTime? ExpirationDateTime { get; set; }

    [JsonPropertyName("firstSeenDateTime")]
    public DateTime? FirstSeenDateTime { get; set; }

    [JsonPropertyName("host")]
    public SecurityHostModel? Host { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastSeenDateTime")]
    public DateTime? LastSeenDateTime { get; set; }

    [JsonPropertyName("lastUpdateDateTime")]
    public DateTime? LastUpdateDateTime { get; set; }

    [JsonPropertyName("nameservers")]
    public List<SecurityWhoisNameserverModel>? Nameservers { get; set; }

    [JsonPropertyName("noc")]
    public SecurityWhoisContactModel? Noc { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("rawWhoisText")]
    public string? RawWhoisText { get; set; }

    [JsonPropertyName("registrant")]
    public SecurityWhoisContactModel? Registrant { get; set; }

    [JsonPropertyName("registrar")]
    public SecurityWhoisContactModel? Registrar { get; set; }

    [JsonPropertyName("registrationDateTime")]
    public DateTime? RegistrationDateTime { get; set; }

    [JsonPropertyName("technical")]
    public SecurityWhoisContactModel? Technical { get; set; }

    [JsonPropertyName("whoisServer")]
    public string? WhoisServer { get; set; }

    [JsonPropertyName("zone")]
    public SecurityWhoisContactModel? Zone { get; set; }
}
