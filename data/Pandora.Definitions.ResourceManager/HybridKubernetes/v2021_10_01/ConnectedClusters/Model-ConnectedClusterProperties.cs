using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HybridKubernetes.v2021_10_01.ConnectedClusters;


internal class ConnectedClusterPropertiesModel
{
    [JsonPropertyName("agentPublicKeyCertificate")]
    [Required]
    public string AgentPublicKeyCertificate { get; set; }

    [JsonPropertyName("agentVersion")]
    public string? AgentVersion { get; set; }

    [JsonPropertyName("connectivityStatus")]
    public ConnectivityStatusConstant? ConnectivityStatus { get; set; }

    [JsonPropertyName("distribution")]
    public string? Distribution { get; set; }

    [JsonPropertyName("infrastructure")]
    public string? Infrastructure { get; set; }

    [JsonPropertyName("kubernetesVersion")]
    public string? KubernetesVersion { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastConnectivityTime")]
    public DateTime? LastConnectivityTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("managedIdentityCertificateExpirationTime")]
    public DateTime? ManagedIdentityCertificateExpirationTime { get; set; }

    [JsonPropertyName("offering")]
    public string? Offering { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("totalCoreCount")]
    public int? TotalCoreCount { get; set; }

    [JsonPropertyName("totalNodeCount")]
    public int? TotalNodeCount { get; set; }
}
