using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2022_12_01.AppPlatform;


internal class DeploymentSettingsModel
{
    [JsonPropertyName("addonConfigs")]
    public Dictionary<string, object>? AddonConfigs { get; set; }

    [JsonPropertyName("containerProbeSettings")]
    public ContainerProbeSettingsModel? ContainerProbeSettings { get; set; }

    [JsonPropertyName("environmentVariables")]
    public Dictionary<string, string>? EnvironmentVariables { get; set; }

    [JsonPropertyName("livenessProbe")]
    public ProbeModel? LivenessProbe { get; set; }

    [JsonPropertyName("readinessProbe")]
    public ProbeModel? ReadinessProbe { get; set; }

    [JsonPropertyName("resourceRequests")]
    public ResourceRequestsModel? ResourceRequests { get; set; }

    [JsonPropertyName("startupProbe")]
    public ProbeModel? StartupProbe { get; set; }

    [JsonPropertyName("terminationGracePeriodSeconds")]
    public int? TerminationGracePeriodSeconds { get; set; }
}
