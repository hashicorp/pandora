using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.ApplicationGateways;


internal class ApplicationGatewayAvailableSslOptionsPropertiesFormatModel
{
    [JsonPropertyName("availableCipherSuites")]
    public List<ApplicationGatewaySslCipherSuiteConstant>? AvailableCipherSuites { get; set; }

    [JsonPropertyName("availableProtocols")]
    public List<ApplicationGatewaySslProtocolConstant>? AvailableProtocols { get; set; }

    [JsonPropertyName("defaultPolicy")]
    public ApplicationGatewaySslPolicyNameConstant? DefaultPolicy { get; set; }

    [JsonPropertyName("predefinedPolicies")]
    public List<SubResourceModel>? PredefinedPolicies { get; set; }
}
