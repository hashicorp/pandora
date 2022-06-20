using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2021_07_01.Workspaces;


internal class WorkspacePropertiesModel
{
    [JsonPropertyName("allowPublicAccessWhenBehindVnet")]
    public bool? AllowPublicAccessWhenBehindVnet { get; set; }

    [JsonPropertyName("applicationInsights")]
    public string? ApplicationInsights { get; set; }

    [JsonPropertyName("containerRegistry")]
    public string? ContainerRegistry { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("discoveryUrl")]
    public string? DiscoveryUrl { get; set; }

    [JsonPropertyName("encryption")]
    public EncryptionPropertyModel? Encryption { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("hbiWorkspace")]
    public bool? HbiWorkspace { get; set; }

    [JsonPropertyName("imageBuildCompute")]
    public string? ImageBuildCompute { get; set; }

    [JsonPropertyName("keyVault")]
    public string? KeyVault { get; set; }

    [JsonPropertyName("mlFlowTrackingUri")]
    public string? MlFlowTrackingUri { get; set; }

    [JsonPropertyName("notebookInfo")]
    public NotebookResourceInfoModel? NotebookInfo { get; set; }

    [JsonPropertyName("primaryUserAssignedIdentity")]
    public string? PrimaryUserAssignedIdentity { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<PrivateEndpointConnectionModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("privateLinkCount")]
    public int? PrivateLinkCount { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessConstant? PublicNetworkAccess { get; set; }

    [JsonPropertyName("serviceManagedResourcesSettings")]
    public ServiceManagedResourcesSettingsModel? ServiceManagedResourcesSettings { get; set; }

    [JsonPropertyName("serviceProvisionedResourceGroup")]
    public string? ServiceProvisionedResourceGroup { get; set; }

    [JsonPropertyName("sharedPrivateLinkResources")]
    public List<SharedPrivateLinkResourceModel>? SharedPrivateLinkResources { get; set; }

    [JsonPropertyName("storageAccount")]
    public string? StorageAccount { get; set; }

    [JsonPropertyName("storageHnsEnabled")]
    public bool? StorageHnsEnabled { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    [JsonPropertyName("workspaceId")]
    public string? WorkspaceId { get; set; }
}
