// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class NetworkaccessNetworkAccessTrafficModel
{
    [JsonPropertyName("action")]
    public NetworkaccessNetworkAccessTrafficActionConstant? Action { get; set; }

    [JsonPropertyName("agentVersion")]
    public string? AgentVersion { get; set; }

    [JsonPropertyName("connectionId")]
    public string? ConnectionId { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("destinationFQDN")]
    public string? DestinationFQDN { get; set; }

    [JsonPropertyName("destinationIp")]
    public string? DestinationIp { get; set; }

    [JsonPropertyName("destinationPort")]
    public int? DestinationPort { get; set; }

    [JsonPropertyName("destinationWebCategory")]
    public NetworkaccessWebCategoryModel? DestinationWebCategory { get; set; }

    [JsonPropertyName("deviceCategory")]
    public NetworkaccessNetworkAccessTrafficDeviceCategoryConstant? DeviceCategory { get; set; }

    [JsonPropertyName("deviceId")]
    public string? DeviceId { get; set; }

    [JsonPropertyName("deviceOperatingSystem")]
    public string? DeviceOperatingSystem { get; set; }

    [JsonPropertyName("deviceOperatingSystemVersion")]
    public string? DeviceOperatingSystemVersion { get; set; }

    [JsonPropertyName("filteringProfileId")]
    public string? FilteringProfileId { get; set; }

    [JsonPropertyName("filteringProfileName")]
    public string? FilteringProfileName { get; set; }

    [JsonPropertyName("headers")]
    public NetworkaccessHeadersModel? Headers { get; set; }

    [JsonPropertyName("initiatingProcessName")]
    public string? InitiatingProcessName { get; set; }

    [JsonPropertyName("networkProtocol")]
    public NetworkaccessNetworkAccessTrafficNetworkProtocolConstant? NetworkProtocol { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("policyId")]
    public string? PolicyId { get; set; }

    [JsonPropertyName("policyName")]
    public string? PolicyName { get; set; }

    [JsonPropertyName("policyRuleId")]
    public string? PolicyRuleId { get; set; }

    [JsonPropertyName("policyRuleName")]
    public string? PolicyRuleName { get; set; }

    [JsonPropertyName("receivedBytes")]
    public int? ReceivedBytes { get; set; }

    [JsonPropertyName("resourceTenantId")]
    public string? ResourceTenantId { get; set; }

    [JsonPropertyName("sentBytes")]
    public int? SentBytes { get; set; }

    [JsonPropertyName("sessionId")]
    public string? SessionId { get; set; }

    [JsonPropertyName("sourceIp")]
    public string? SourceIp { get; set; }

    [JsonPropertyName("sourcePort")]
    public int? SourcePort { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    [JsonPropertyName("trafficType")]
    public NetworkaccessNetworkAccessTrafficTrafficTypeConstant? TrafficType { get; set; }

    [JsonPropertyName("transactionId")]
    public string? TransactionId { get; set; }

    [JsonPropertyName("transportProtocol")]
    public NetworkaccessNetworkAccessTrafficTransportProtocolConstant? TransportProtocol { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    [JsonPropertyName("userPrincipalName")]
    public string? UserPrincipalName { get; set; }
}
