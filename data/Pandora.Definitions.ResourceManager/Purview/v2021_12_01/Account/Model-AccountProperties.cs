using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Purview.v2021_12_01.Account;


internal class AccountPropertiesModel
{
    [JsonPropertyName("accountStatus")]
    public AccountStatusModel? AccountStatus { get; set; }

    [JsonPropertyName("cloudConnectors")]
    public CloudConnectorsModel? CloudConnectors { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("createdBy")]
    public string? CreatedBy { get; set; }

    [JsonPropertyName("createdByObjectId")]
    public string? CreatedByObjectId { get; set; }

    [JsonPropertyName("endpoints")]
    public AccountEndpointsModel? Endpoints { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("managedEventHubState")]
    public ManagedEventHubStateConstant? ManagedEventHubState { get; set; }

    [JsonPropertyName("managedResourceGroupName")]
    public string? ManagedResourceGroupName { get; set; }

    [JsonPropertyName("managedResources")]
    public ManagedResourcesModel? ManagedResources { get; set; }

    [JsonPropertyName("managedResourcesPublicNetworkAccess")]
    public ManagedResourcesPublicNetworkAccessConstant? ManagedResourcesPublicNetworkAccess { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<PrivateEndpointConnectionModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessConstant? PublicNetworkAccess { get; set; }
}
