using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2021_07_01.MachineLearningComputes;


internal class InstanceTypeSchemaResourcesModel
{
    [JsonPropertyName("limits")]
    public Dictionary<string, string>? Limits { get; set; }

    [JsonPropertyName("requests")]
    public Dictionary<string, string>? Requests { get; set; }
}
