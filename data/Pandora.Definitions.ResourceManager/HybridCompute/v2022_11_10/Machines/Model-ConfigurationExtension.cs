using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HybridCompute.v2022_11_10.Machines;


internal class ConfigurationExtensionModel
{
    [JsonPropertyName("publisher")]
    public string? Publisher { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}
