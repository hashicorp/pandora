using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.LinkedServices;


internal class LinkedServiceModel
{
    [JsonPropertyName("annotations")]
    public List<object>? Annotations { get; set; }

    [JsonPropertyName("connectVia")]
    public IntegrationRuntimeReferenceModel? ConnectVia { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("parameters")]
    public Dictionary<string, ParameterSpecificationModel>? Parameters { get; set; }

    [JsonPropertyName("type")]
    [Required]
    public string Type { get; set; }
}
