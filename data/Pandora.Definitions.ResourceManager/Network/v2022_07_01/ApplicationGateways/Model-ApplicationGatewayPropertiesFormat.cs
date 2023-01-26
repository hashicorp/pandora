using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ApplicationGateways;


internal class ApplicationGatewayPropertiesFormatModel
{
    [JsonPropertyName("authenticationCertificates")]
    public List<ApplicationGatewayAuthenticationCertificateModel>? AuthenticationCertificates { get; set; }

    [JsonPropertyName("autoscaleConfiguration")]
    public ApplicationGatewayAutoscaleConfigurationModel? AutoscaleConfiguration { get; set; }

    [JsonPropertyName("backendAddressPools")]
    public List<ApplicationGatewayBackendAddressPoolModel>? BackendAddressPools { get; set; }

    [JsonPropertyName("backendHttpSettingsCollection")]
    public List<ApplicationGatewayBackendHTTPSettingsModel>? BackendHTTPSettingsCollection { get; set; }

    [JsonPropertyName("backendSettingsCollection")]
    public List<ApplicationGatewayBackendSettingsModel>? BackendSettingsCollection { get; set; }

    [JsonPropertyName("customErrorConfigurations")]
    public List<ApplicationGatewayCustomErrorModel>? CustomErrorConfigurations { get; set; }

    [JsonPropertyName("enableFips")]
    public bool? EnableFips { get; set; }

    [JsonPropertyName("enableHttp2")]
    public bool? EnableHTTP2 { get; set; }

    [JsonPropertyName("firewallPolicy")]
    public SubResourceModel? FirewallPolicy { get; set; }

    [JsonPropertyName("forceFirewallPolicyAssociation")]
    public bool? ForceFirewallPolicyAssociation { get; set; }

    [JsonPropertyName("frontendIPConfigurations")]
    public List<ApplicationGatewayFrontendIPConfigurationModel>? FrontendIPConfigurations { get; set; }

    [JsonPropertyName("frontendPorts")]
    public List<ApplicationGatewayFrontendPortModel>? FrontendPorts { get; set; }

    [JsonPropertyName("gatewayIPConfigurations")]
    public List<ApplicationGatewayIPConfigurationModel>? GatewayIPConfigurations { get; set; }

    [JsonPropertyName("globalConfiguration")]
    public ApplicationGatewayGlobalConfigurationModel? GlobalConfiguration { get; set; }

    [JsonPropertyName("httpListeners")]
    public List<ApplicationGatewayHTTPListenerModel>? HTTPListeners { get; set; }

    [JsonPropertyName("listeners")]
    public List<ApplicationGatewayListenerModel>? Listeners { get; set; }

    [JsonPropertyName("loadDistributionPolicies")]
    public List<ApplicationGatewayLoadDistributionPolicyModel>? LoadDistributionPolicies { get; set; }

    [JsonPropertyName("operationalState")]
    public ApplicationGatewayOperationalStateConstant? OperationalState { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<ApplicationGatewayPrivateEndpointConnectionModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("privateLinkConfigurations")]
    public List<ApplicationGatewayPrivateLinkConfigurationModel>? PrivateLinkConfigurations { get; set; }

    [JsonPropertyName("probes")]
    public List<ApplicationGatewayProbeModel>? Probes { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("redirectConfigurations")]
    public List<ApplicationGatewayRedirectConfigurationModel>? RedirectConfigurations { get; set; }

    [JsonPropertyName("requestRoutingRules")]
    public List<ApplicationGatewayRequestRoutingRuleModel>? RequestRoutingRules { get; set; }

    [JsonPropertyName("resourceGuid")]
    public string? ResourceGuid { get; set; }

    [JsonPropertyName("rewriteRuleSets")]
    public List<ApplicationGatewayRewriteRuleSetModel>? RewriteRuleSets { get; set; }

    [JsonPropertyName("routingRules")]
    public List<ApplicationGatewayRoutingRuleModel>? RoutingRules { get; set; }

    [JsonPropertyName("sku")]
    public ApplicationGatewaySkuModel? Sku { get; set; }

    [JsonPropertyName("sslCertificates")]
    public List<ApplicationGatewaySslCertificateModel>? SslCertificates { get; set; }

    [JsonPropertyName("sslPolicy")]
    public ApplicationGatewaySslPolicyModel? SslPolicy { get; set; }

    [JsonPropertyName("sslProfiles")]
    public List<ApplicationGatewaySslProfileModel>? SslProfiles { get; set; }

    [JsonPropertyName("trustedClientCertificates")]
    public List<ApplicationGatewayTrustedClientCertificateModel>? TrustedClientCertificates { get; set; }

    [JsonPropertyName("trustedRootCertificates")]
    public List<ApplicationGatewayTrustedRootCertificateModel>? TrustedRootCertificates { get; set; }

    [JsonPropertyName("urlPathMaps")]
    public List<ApplicationGatewayUrlPathMapModel>? UrlPathMaps { get; set; }

    [JsonPropertyName("webApplicationFirewallConfiguration")]
    public ApplicationGatewayWebApplicationFirewallConfigurationModel? WebApplicationFirewallConfiguration { get; set; }
}
