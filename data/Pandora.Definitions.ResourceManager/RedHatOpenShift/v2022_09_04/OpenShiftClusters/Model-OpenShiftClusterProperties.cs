using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RedHatOpenShift.v2022_09_04.OpenShiftClusters;


internal class OpenShiftClusterPropertiesModel
{
    [JsonPropertyName("apiserverProfile")]
    public APIServerProfileModel? ApiserverProfile { get; set; }

    [JsonPropertyName("clusterProfile")]
    public ClusterProfileModel? ClusterProfile { get; set; }

    [JsonPropertyName("consoleProfile")]
    public ConsoleProfileModel? ConsoleProfile { get; set; }

    [JsonPropertyName("ingressProfiles")]
    public List<IngressProfileModel>? IngressProfiles { get; set; }

    [JsonPropertyName("masterProfile")]
    public MasterProfileModel? MasterProfile { get; set; }

    [JsonPropertyName("networkProfile")]
    public NetworkProfileModel? NetworkProfile { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("servicePrincipalProfile")]
    public ServicePrincipalProfileModel? ServicePrincipalProfile { get; set; }

    [JsonPropertyName("workerProfiles")]
    public List<WorkerProfileModel>? WorkerProfiles { get; set; }
}
