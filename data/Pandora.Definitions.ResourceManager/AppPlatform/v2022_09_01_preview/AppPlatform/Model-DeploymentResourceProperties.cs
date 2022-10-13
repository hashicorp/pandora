using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2022_09_01_preview.AppPlatform;


internal class DeploymentResourcePropertiesModel
{
    [JsonPropertyName("active")]
    public bool? Active { get; set; }

    [JsonPropertyName("deploymentSettings")]
    public DeploymentSettingsModel? DeploymentSettings { get; set; }

    [JsonPropertyName("instances")]
    public List<DeploymentInstanceModel>? Instances { get; set; }

    [JsonPropertyName("provisioningState")]
    public DeploymentResourceProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("source")]
    public UserSourceInfoModel? Source { get; set; }

    [JsonPropertyName("status")]
    public DeploymentResourceStatusConstant? Status { get; set; }
}
