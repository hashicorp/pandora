using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Databricks.v2023_02_01.Workspaces;


internal class WorkspacePropertiesModel
{
    [JsonPropertyName("authorizations")]
    public List<WorkspaceProviderAuthorizationModel>? Authorizations { get; set; }

    [JsonPropertyName("createdBy")]
    public CreatedByModel? CreatedBy { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("diskEncryptionSetId")]
    public string? DiskEncryptionSetId { get; set; }

    [JsonPropertyName("encryption")]
    public WorkspacePropertiesEncryptionModel? Encryption { get; set; }

    [JsonPropertyName("managedDiskIdentity")]
    public ManagedIdentityConfigurationModel? ManagedDiskIdentity { get; set; }

    [JsonPropertyName("managedResourceGroupId")]
    [Required]
    public string ManagedResourceGroupId { get; set; }

    [JsonPropertyName("parameters")]
    public WorkspaceCustomParametersModel? Parameters { get; set; }

    [JsonPropertyName("privateEndpointConnections")]
    public List<PrivateEndpointConnectionModel>? PrivateEndpointConnections { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessConstant? PublicNetworkAccess { get; set; }

    [JsonPropertyName("requiredNsgRules")]
    public RequiredNsgRulesConstant? RequiredNsgRules { get; set; }

    [JsonPropertyName("storageAccountIdentity")]
    public ManagedIdentityConfigurationModel? StorageAccountIdentity { get; set; }

    [JsonPropertyName("uiDefinitionUri")]
    public string? UiDefinitionUri { get; set; }

    [JsonPropertyName("updatedBy")]
    public CreatedByModel? UpdatedBy { get; set; }

    [JsonPropertyName("workspaceId")]
    public string? WorkspaceId { get; set; }

    [JsonPropertyName("workspaceUrl")]
    public string? WorkspaceUrl { get; set; }
}
