using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2022_09_01.Deployments;


internal class WhatIfPropertyChangeModel
{
    [JsonPropertyName("after")]
    public object? After { get; set; }

    [JsonPropertyName("before")]
    public object? Before { get; set; }

    [JsonPropertyName("children")]
    public List<WhatIfPropertyChangeModel>? Children { get; set; }

    [JsonPropertyName("path")]
    [Required]
    public string Path { get; set; }

    [JsonPropertyName("propertyChangeType")]
    [Required]
    public PropertyChangeTypeConstant PropertyChangeType { get; set; }
}
