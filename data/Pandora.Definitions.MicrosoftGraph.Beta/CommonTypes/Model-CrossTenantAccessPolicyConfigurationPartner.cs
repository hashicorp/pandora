// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CrossTenantAccessPolicyConfigurationPartnerModel
{
    [JsonPropertyName("automaticUserConsentSettings")]
    public InboundOutboundPolicyConfigurationModel? AutomaticUserConsentSettings { get; set; }

    [JsonPropertyName("b2bCollaborationInbound")]
    public CrossTenantAccessPolicyB2BSettingModel? B2bCollaborationInbound { get; set; }

    [JsonPropertyName("b2bCollaborationOutbound")]
    public CrossTenantAccessPolicyB2BSettingModel? B2bCollaborationOutbound { get; set; }

    [JsonPropertyName("b2bDirectConnectInbound")]
    public CrossTenantAccessPolicyB2BSettingModel? B2bDirectConnectInbound { get; set; }

    [JsonPropertyName("b2bDirectConnectOutbound")]
    public CrossTenantAccessPolicyB2BSettingModel? B2bDirectConnectOutbound { get; set; }

    [JsonPropertyName("identitySynchronization")]
    public CrossTenantIdentitySyncPolicyPartnerModel? IdentitySynchronization { get; set; }

    [JsonPropertyName("inboundTrust")]
    public CrossTenantAccessPolicyInboundTrustModel? InboundTrust { get; set; }

    [JsonPropertyName("isServiceProvider")]
    public bool? IsServiceProvider { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    [JsonPropertyName("tenantRestrictions")]
    public CrossTenantAccessPolicyTenantRestrictionsModel? TenantRestrictions { get; set; }
}
