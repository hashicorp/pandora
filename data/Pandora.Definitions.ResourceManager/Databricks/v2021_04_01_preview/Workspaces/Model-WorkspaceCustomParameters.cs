using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Databricks.v2021_04_01_preview.Workspaces;


internal class WorkspaceCustomParametersModel
{
    [JsonPropertyName("amlWorkspaceId")]
    public WorkspaceCustomStringParameterModel? AmlWorkspaceId { get; set; }

    [JsonPropertyName("customPrivateSubnetName")]
    public WorkspaceCustomStringParameterModel? CustomPrivateSubnetName { get; set; }

    [JsonPropertyName("customPublicSubnetName")]
    public WorkspaceCustomStringParameterModel? CustomPublicSubnetName { get; set; }

    [JsonPropertyName("customVirtualNetworkId")]
    public WorkspaceCustomStringParameterModel? CustomVirtualNetworkId { get; set; }

    [JsonPropertyName("enableNoPublicIp")]
    public WorkspaceCustomBooleanParameterModel? EnableNoPublicIP { get; set; }

    [JsonPropertyName("encryption")]
    public WorkspaceEncryptionParameterModel? Encryption { get; set; }

    [JsonPropertyName("loadBalancerBackendPoolName")]
    public WorkspaceCustomStringParameterModel? LoadBalancerBackendPoolName { get; set; }

    [JsonPropertyName("loadBalancerId")]
    public WorkspaceCustomStringParameterModel? LoadBalancerId { get; set; }

    [JsonPropertyName("natGatewayName")]
    public WorkspaceCustomStringParameterModel? NatGatewayName { get; set; }

    [JsonPropertyName("prepareEncryption")]
    public WorkspaceCustomBooleanParameterModel? PrepareEncryption { get; set; }

    [JsonPropertyName("publicIpName")]
    public WorkspaceCustomStringParameterModel? PublicIPName { get; set; }

    [JsonPropertyName("requireInfrastructureEncryption")]
    public WorkspaceCustomBooleanParameterModel? RequireInfrastructureEncryption { get; set; }

    [JsonPropertyName("resourceTags")]
    public WorkspaceCustomObjectParameterModel? ResourceTags { get; set; }

    [JsonPropertyName("storageAccountName")]
    public WorkspaceCustomStringParameterModel? StorageAccountName { get; set; }

    [JsonPropertyName("storageAccountSkuName")]
    public WorkspaceCustomStringParameterModel? StorageAccountSkuName { get; set; }

    [JsonPropertyName("vnetAddressPrefix")]
    public WorkspaceCustomStringParameterModel? VnetAddressPrefix { get; set; }
}
