using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.WebApplicationFirewallPolicies;


internal class ApplicationGatewaySslPolicyModel
{
    [JsonPropertyName("cipherSuites")]
    public List<ApplicationGatewaySslCipherSuiteConstant>? CipherSuites { get; set; }

    [JsonPropertyName("disabledSslProtocols")]
    public List<ApplicationGatewaySslProtocolConstant>? DisabledSslProtocols { get; set; }

    [JsonPropertyName("minProtocolVersion")]
    public ApplicationGatewaySslProtocolConstant? MinProtocolVersion { get; set; }

    [JsonPropertyName("policyName")]
    public ApplicationGatewaySslPolicyNameConstant? PolicyName { get; set; }

    [JsonPropertyName("policyType")]
    public ApplicationGatewaySslPolicyTypeConstant? PolicyType { get; set; }
}
