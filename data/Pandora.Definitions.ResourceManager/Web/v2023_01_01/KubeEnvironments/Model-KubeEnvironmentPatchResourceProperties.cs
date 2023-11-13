using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.KubeEnvironments;


internal class KubeEnvironmentPatchResourcePropertiesModel
{
    [JsonPropertyName("aksResourceID")]
    public string? AksResourceID { get; set; }

    [JsonPropertyName("appLogsConfiguration")]
    public AppLogsConfigurationModel? AppLogsConfiguration { get; set; }

    [JsonPropertyName("arcConfiguration")]
    public ArcConfigurationModel? ArcConfiguration { get; set; }

    [JsonPropertyName("containerAppsConfiguration")]
    public ContainerAppsConfigurationModel? ContainerAppsConfiguration { get; set; }

    [JsonPropertyName("defaultDomain")]
    public string? DefaultDomain { get; set; }

    [JsonPropertyName("deploymentErrors")]
    public string? DeploymentErrors { get; set; }

    [JsonPropertyName("internalLoadBalancerEnabled")]
    public bool? InternalLoadBalancerEnabled { get; set; }

    [JsonPropertyName("provisioningState")]
    public KubeEnvironmentProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("staticIp")]
    public string? StaticIP { get; set; }
}
