using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2023_12_01.AppPlatform;


internal class PredefinedAcceleratorPropertiesModel
{
    [JsonPropertyName("acceleratorTags")]
    public List<string>? AcceleratorTags { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("iconUrl")]
    public string? IconUrl { get; set; }

    [JsonPropertyName("provisioningState")]
    public PredefinedAcceleratorProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("state")]
    public PredefinedAcceleratorStateConstant? State { get; set; }
}
