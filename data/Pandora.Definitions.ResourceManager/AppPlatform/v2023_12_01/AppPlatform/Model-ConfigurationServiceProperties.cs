using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2023_12_01.AppPlatform;


internal class ConfigurationServicePropertiesModel
{
    [JsonPropertyName("generation")]
    public ConfigurationServiceGenerationConstant? Generation { get; set; }

    [JsonPropertyName("instances")]
    public List<ConfigurationServiceInstanceModel>? Instances { get; set; }

    [JsonPropertyName("provisioningState")]
    public ConfigurationServiceProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("resourceRequests")]
    public ConfigurationServiceResourceRequestsModel? ResourceRequests { get; set; }

    [JsonPropertyName("settings")]
    public ConfigurationServiceSettingsModel? Settings { get; set; }
}
