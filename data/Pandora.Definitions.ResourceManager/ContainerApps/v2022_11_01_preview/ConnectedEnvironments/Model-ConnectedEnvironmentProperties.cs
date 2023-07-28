using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_11_01_preview.ConnectedEnvironments;


internal class ConnectedEnvironmentPropertiesModel
{
    [JsonPropertyName("customDomainConfiguration")]
    public CustomDomainConfigurationModel? CustomDomainConfiguration { get; set; }

    [JsonPropertyName("daprAIConnectionString")]
    public string? DaprAIConnectionString { get; set; }

    [JsonPropertyName("defaultDomain")]
    public string? DefaultDomain { get; set; }

    [JsonPropertyName("deploymentErrors")]
    public string? DeploymentErrors { get; set; }

    [JsonPropertyName("provisioningState")]
    public ConnectedEnvironmentProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("staticIp")]
    public string? StaticIP { get; set; }
}
