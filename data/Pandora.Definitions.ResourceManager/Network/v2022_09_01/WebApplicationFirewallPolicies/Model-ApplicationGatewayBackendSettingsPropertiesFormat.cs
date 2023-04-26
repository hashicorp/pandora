using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_09_01.WebApplicationFirewallPolicies;


internal class ApplicationGatewayBackendSettingsPropertiesFormatModel
{
    [JsonPropertyName("hostName")]
    public string? HostName { get; set; }

    [JsonPropertyName("pickHostNameFromBackendAddress")]
    public bool? PickHostNameFromBackendAddress { get; set; }

    [JsonPropertyName("port")]
    public int? Port { get; set; }

    [JsonPropertyName("probe")]
    public SubResourceModel? Probe { get; set; }

    [JsonPropertyName("protocol")]
    public ApplicationGatewayProtocolConstant? Protocol { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("timeout")]
    public int? Timeout { get; set; }

    [JsonPropertyName("trustedRootCertificates")]
    public List<SubResourceModel>? TrustedRootCertificates { get; set; }
}
