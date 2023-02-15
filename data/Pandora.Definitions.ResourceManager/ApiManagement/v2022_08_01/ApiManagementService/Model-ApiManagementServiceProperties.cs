using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.ApiManagementService;


internal class ApiManagementServicePropertiesModel
{
    [JsonPropertyName("additionalLocations")]
    public List<AdditionalLocationModel>? AdditionalLocations { get; set; }

    [JsonPropertyName("apiVersionConstraint")]
    public ApiVersionConstraintModel? ApiVersionConstraint { get; set; }

    [JsonPropertyName("certificates")]
    public List<CertificateConfigurationModel>? Certificates { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdAtUtc")]
    public DateTime? CreatedAtUtc { get; set; }

    [JsonPropertyName("customProperties")]
    public Dictionary<string, string>? CustomProperties { get; set; }

    [JsonPropertyName("developerPortalUrl")]
    public string? DeveloperPortalUrl { get; set; }

    [JsonPropertyName("disableGateway")]
    public bool? DisableGateway { get; set; }

    [JsonPropertyName("enableClientCertificate")]
    public bool? EnableClientCertificate { get; set; }

    [JsonPropertyName("gatewayRegionalUrl")]
    public string? GatewayRegionalUrl { get; set; }

    [JsonPropertyName("gatewayUrl")]
    public string? GatewayUrl { get; set; }

    [JsonPropertyName("hostnameConfigurations")]
    public List<HostnameConfigurationModel>? HostnameConfigurations { get; set; }

    [JsonPropertyName("managementApiUrl")]
    public string? ManagementApiUrl { get; set; }

    [JsonPropertyName("natGatewayState")]
    public NatGatewayStateConstant? NatGatewayState { get; set; }

    [JsonPropertyName("notificationSenderEmail")]
    public string? NotificationSenderEmail { get; set; }

    [JsonPropertyName("outboundPublicIPAddresses")]
    public List<string>? OutboundPublicIPAddresses { get; set; }

    [JsonPropertyName("platformVersion")]
    public PlatformVersionConstant? PlatformVersion { get; set; }

    [JsonPropertyName("portalUrl")]
    public string? PortalUrl { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<RemotePrivateEndpointConnectionWrapperModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("privateIPAddresses")]
    public List<string>? PrivateIPAddresses { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("publicIpAddressId")]
    public string? PublicIPAddressId { get; set; }

    [JsonPropertyName("publicIPAddresses")]
    public List<string>? PublicIPAddresses { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessConstant? PublicNetworkAccess { get; set; }

    [JsonPropertyName("publisherEmail")]
    [Required]
    public string PublisherEmail { get; set; }

    [JsonPropertyName("publisherName")]
    [Required]
    public string PublisherName { get; set; }

    [JsonPropertyName("restore")]
    public bool? Restore { get; set; }

    [JsonPropertyName("scmUrl")]
    public string? ScmUrl { get; set; }

    [JsonPropertyName("targetProvisioningState")]
    public string? TargetProvisioningState { get; set; }

    [JsonPropertyName("virtualNetworkConfiguration")]
    public VirtualNetworkConfigurationModel? VirtualNetworkConfiguration { get; set; }

    [JsonPropertyName("virtualNetworkType")]
    public VirtualNetworkTypeConstant? VirtualNetworkType { get; set; }
}
