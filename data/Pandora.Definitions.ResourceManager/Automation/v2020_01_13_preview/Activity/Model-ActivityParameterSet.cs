using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2020_01_13_preview.Activity;


internal class ActivityParameterSetModel
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("parameters")]
    public List<ActivityParameterModel>? Parameters { get; set; }
}
