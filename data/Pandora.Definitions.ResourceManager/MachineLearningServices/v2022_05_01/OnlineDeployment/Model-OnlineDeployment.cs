using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.OnlineDeployment;


internal abstract class OnlineDeploymentModel
{
    [JsonPropertyName("appInsightsEnabled")]
    public bool? AppInsightsEnabled { get; set; }

    [JsonPropertyName("codeConfiguration")]
    public CodeConfigurationModel? CodeConfiguration { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("endpointComputeType")]
    [ProvidesTypeHint]
    [Required]
    public EndpointComputeTypeConstant EndpointComputeType { get; set; }

    [JsonPropertyName("environmentId")]
    public string? EnvironmentId { get; set; }

    [JsonPropertyName("environmentVariables")]
    public Dictionary<string, string>? EnvironmentVariables { get; set; }

    [JsonPropertyName("instanceType")]
    public string? InstanceType { get; set; }

    [JsonPropertyName("livenessProbe")]
    public ProbeSettingsModel? LivenessProbe { get; set; }

    [JsonPropertyName("model")]
    public string? Model { get; set; }

    [JsonPropertyName("modelMountPath")]
    public string? ModelMountPath { get; set; }

    [JsonPropertyName("properties")]
    public Dictionary<string, string>? Properties { get; set; }

    [JsonPropertyName("provisioningState")]
    public DeploymentProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("readinessProbe")]
    public ProbeSettingsModel? ReadinessProbe { get; set; }

    [JsonPropertyName("requestSettings")]
    public OnlineRequestSettingsModel? RequestSettings { get; set; }

    [JsonPropertyName("scaleSettings")]
    public OnlineScaleSettingsModel? ScaleSettings { get; set; }
}
