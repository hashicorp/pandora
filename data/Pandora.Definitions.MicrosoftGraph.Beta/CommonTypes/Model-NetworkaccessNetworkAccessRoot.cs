// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class NetworkaccessNetworkAccessRootModel
{
    [JsonPropertyName("connectivity")]
    public NetworkaccessConnectivityModel? Connectivity { get; set; }

    [JsonPropertyName("filteringPolicies")]
    public List<NetworkaccessFilteringPolicyModel>? FilteringPolicies { get; set; }

    [JsonPropertyName("filteringProfiles")]
    public List<NetworkaccessFilteringProfileModel>? FilteringProfiles { get; set; }

    [JsonPropertyName("forwardingPolicies")]
    public List<NetworkaccessForwardingPolicyModel>? ForwardingPolicies { get; set; }

    [JsonPropertyName("forwardingProfiles")]
    public List<NetworkaccessForwardingProfileModel>? ForwardingProfiles { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("logs")]
    public NetworkaccessLogsModel? Logs { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("reports")]
    public NetworkaccessReportsModel? Reports { get; set; }

    [JsonPropertyName("settings")]
    public NetworkaccessSettingsModel? Settings { get; set; }

    [JsonPropertyName("tenantStatus")]
    public NetworkaccessTenantStatusModel? TenantStatus { get; set; }
}
