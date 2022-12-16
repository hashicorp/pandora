using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2021_10_01_preview.Subscriptions;


internal class QueryFunctionModel
{
    [JsonPropertyName("bindingType")]
    [Required]
    public string BindingType { get; set; }

    [JsonPropertyName("inputs")]
    [Required]
    public List<FunctionInputModel> Inputs { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }

    [JsonPropertyName("output")]
    [Required]
    public FunctionOutputModel Output { get; set; }

    [JsonPropertyName("type")]
    [Required]
    public string Type { get; set; }
}
