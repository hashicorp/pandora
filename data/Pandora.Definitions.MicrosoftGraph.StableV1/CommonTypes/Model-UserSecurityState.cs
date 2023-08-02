// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class UserSecurityStateModel
{
    [JsonPropertyName("aadUserId")]
    public string? AadUserId { get; set; }

    [JsonPropertyName("accountName")]
    public string? AccountName { get; set; }

    [JsonPropertyName("domainName")]
    public string? DomainName { get; set; }

    [JsonPropertyName("emailRole")]
    public EmailRoleConstant? EmailRole { get; set; }

    [JsonPropertyName("isVpn")]
    public bool? IsVpn { get; set; }

    [JsonPropertyName("logonDateTime")]
    public DateTime? LogonDateTime { get; set; }

    [JsonPropertyName("logonId")]
    public string? LogonId { get; set; }

    [JsonPropertyName("logonIp")]
    public string? LogonIp { get; set; }

    [JsonPropertyName("logonLocation")]
    public string? LogonLocation { get; set; }

    [JsonPropertyName("logonType")]
    public LogonTypeConstant? LogonType { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("onPremisesSecurityIdentifier")]
    public string? OnPremisesSecurityIdentifier { get; set; }

    [JsonPropertyName("riskScore")]
    public string? RiskScore { get; set; }

    [JsonPropertyName("userAccountType")]
    public UserAccountSecurityTypeConstant? UserAccountType { get; set; }

    [JsonPropertyName("userPrincipalName")]
    public string? UserPrincipalName { get; set; }
}
