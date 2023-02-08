using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2015_10_31.Activity;


internal class ActivityParameterModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("isDynamic")]
    public bool? IsDynamic { get; set; }

    [JsonPropertyName("isMandatory")]
    public bool? IsMandatory { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("position")]
    public int? Position { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("validationSet")]
    public List<ActivityParameterValidationSetModel>? ValidationSet { get; set; }

    [JsonPropertyName("valueFromPipeline")]
    public bool? ValueFromPipeline { get; set; }

    [JsonPropertyName("valueFromPipelineByPropertyName")]
    public bool? ValueFromPipelineByPropertyName { get; set; }

    [JsonPropertyName("valueFromRemainingArguments")]
    public bool? ValueFromRemainingArguments { get; set; }
}
