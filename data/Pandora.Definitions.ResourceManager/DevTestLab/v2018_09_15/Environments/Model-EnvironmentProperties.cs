using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.Environments;


internal class EnvironmentPropertiesModel
{
    [JsonPropertyName("armTemplateDisplayName")]
    public string? ArmTemplateDisplayName { get; set; }

    [JsonPropertyName("createdByUser")]
    public string? CreatedByUser { get; set; }

    [JsonPropertyName("deploymentProperties")]
    public EnvironmentDeploymentPropertiesModel? DeploymentProperties { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("resourceGroupId")]
    public string? ResourceGroupId { get; set; }

    [JsonPropertyName("uniqueIdentifier")]
    public string? UniqueIdentifier { get; set; }
}
