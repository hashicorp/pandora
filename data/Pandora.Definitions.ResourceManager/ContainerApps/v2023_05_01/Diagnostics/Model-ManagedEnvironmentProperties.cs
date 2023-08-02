using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2023_05_01.Diagnostics;


internal class ManagedEnvironmentPropertiesModel
{
    [JsonPropertyName("appLogsConfiguration")]
    public AppLogsConfigurationModel? AppLogsConfiguration { get; set; }

    [JsonPropertyName("customDomainConfiguration")]
    public CustomDomainConfigurationModel? CustomDomainConfiguration { get; set; }

    [JsonPropertyName("daprAIConnectionString")]
    public string? DaprAIConnectionString { get; set; }

    [JsonPropertyName("daprAIInstrumentationKey")]
    public string? DaprAIInstrumentationKey { get; set; }

    [JsonPropertyName("daprConfiguration")]
    public DaprConfigurationModel? DaprConfiguration { get; set; }

    [JsonPropertyName("defaultDomain")]
    public string? DefaultDomain { get; set; }

    [JsonPropertyName("deploymentErrors")]
    public string? DeploymentErrors { get; set; }

    [JsonPropertyName("eventStreamEndpoint")]
    public string? EventStreamEndpoint { get; set; }

    [JsonPropertyName("infrastructureResourceGroup")]
    public string? InfrastructureResourceGroup { get; set; }

    [JsonPropertyName("kedaConfiguration")]
    public KedaConfigurationModel? KedaConfiguration { get; set; }

    [JsonPropertyName("peerAuthentication")]
    public ManagedEnvironmentPropertiesPeerAuthenticationModel? PeerAuthentication { get; set; }

    [JsonPropertyName("provisioningState")]
    public EnvironmentProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("staticIp")]
    public string? StaticIP { get; set; }

    [JsonPropertyName("vnetConfiguration")]
    public VnetConfigurationModel? VnetConfiguration { get; set; }

    [JsonPropertyName("workloadProfiles")]
    public List<WorkloadProfileModel>? WorkloadProfiles { get; set; }

    [JsonPropertyName("zoneRedundant")]
    public bool? ZoneRedundant { get; set; }
}
