using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NotificationHubs.v2023_09_01.Namespaces;


internal class NamespacePropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("critical")]
    public bool? Critical { get; set; }

    [JsonPropertyName("dataCenter")]
    public string? DataCenter { get; set; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("metricId")]
    public string? MetricId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("namespaceType")]
    public NamespaceTypeConstant? NamespaceType { get; set; }

    [JsonPropertyName("networkAcls")]
    public NetworkAclsModel? NetworkAcls { get; set; }

    [JsonPropertyName("pnsCredentials")]
    public PnsCredentialsModel? PnsCredentials { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<PrivateEndpointConnectionResourceModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("provisioningState")]
    public OperationProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessConstant? PublicNetworkAccess { get; set; }

    [JsonPropertyName("region")]
    public string? Region { get; set; }

    [JsonPropertyName("replicationRegion")]
    public ReplicationRegionConstant? ReplicationRegion { get; set; }

    [JsonPropertyName("scaleUnit")]
    public string? ScaleUnit { get; set; }

    [JsonPropertyName("serviceBusEndpoint")]
    public string? ServiceBusEndpoint { get; set; }

    [JsonPropertyName("status")]
    public NamespaceStatusConstant? Status { get; set; }

    [JsonPropertyName("subscriptionId")]
    public string? SubscriptionId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }

    [JsonPropertyName("zoneRedundancy")]
    public ZoneRedundancyPreferenceConstant? ZoneRedundancy { get; set; }
}
