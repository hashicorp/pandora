using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2023_09_01_preview.AppPlatform;


internal class CustomizedAcceleratorPropertiesModel
{
    [JsonPropertyName("acceleratorTags")]
    public List<string>? AcceleratorTags { get; set; }

    [JsonPropertyName("acceleratorType")]
    public CustomizedAcceleratorTypeConstant? AcceleratorType { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("gitRepository")]
    [Required]
    public AcceleratorGitRepositoryModel GitRepository { get; set; }

    [JsonPropertyName("iconUrl")]
    public string? IconUrl { get; set; }

    [JsonPropertyName("imports")]
    public List<string>? Imports { get; set; }

    [JsonPropertyName("provisioningState")]
    public CustomizedAcceleratorProvisioningStateConstant? ProvisioningState { get; set; }
}
