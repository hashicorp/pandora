using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.ApplicationGateways;


internal class ApplicationGatewayHttpListenerPropertiesFormatModel
{
    [JsonPropertyName("customErrorConfigurations")]
    public List<ApplicationGatewayCustomErrorModel>? CustomErrorConfigurations { get; set; }

    [JsonPropertyName("firewallPolicy")]
    public SubResourceModel? FirewallPolicy { get; set; }

    [JsonPropertyName("frontendIPConfiguration")]
    public SubResourceModel? FrontendIPConfiguration { get; set; }

    [JsonPropertyName("frontendPort")]
    public SubResourceModel? FrontendPort { get; set; }

    [JsonPropertyName("hostName")]
    public string? HostName { get; set; }

    [JsonPropertyName("hostNames")]
    public List<string>? HostNames { get; set; }

    [JsonPropertyName("protocol")]
    public ApplicationGatewayProtocolConstant? Protocol { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("requireServerNameIndication")]
    public bool? RequireServerNameIndication { get; set; }

    [JsonPropertyName("sslCertificate")]
    public SubResourceModel? SslCertificate { get; set; }

    [JsonPropertyName("sslProfile")]
    public SubResourceModel? SslProfile { get; set; }
}
