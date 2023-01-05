using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Cognitive.v2022_12_01.Deployments;


internal class DeploymentPropertiesModel
{
    [JsonPropertyName("callRateLimit")]
    public CallRateLimitModel? CallRateLimit { get; set; }

    [JsonPropertyName("capabilities")]
    public Dictionary<string, string>? Capabilities { get; set; }

    [JsonPropertyName("model")]
    public DeploymentModelModel? Model { get; set; }

    [JsonPropertyName("provisioningState")]
    public DeploymentProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("raiPolicyName")]
    public string? RaiPolicyName { get; set; }

    [JsonPropertyName("scaleSettings")]
    public DeploymentScaleSettingsModel? ScaleSettings { get; set; }
}
