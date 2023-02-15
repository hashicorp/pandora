using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.ApiOperation;


internal class RepresentationContractModel
{
    [JsonPropertyName("contentType")]
    [Required]
    public string ContentType { get; set; }

    [JsonPropertyName("examples")]
    public Dictionary<string, ParameterExampleContractModel>? Examples { get; set; }

    [JsonPropertyName("formParameters")]
    public List<ParameterContractModel>? FormParameters { get; set; }

    [JsonPropertyName("schemaId")]
    public string? SchemaId { get; set; }

    [JsonPropertyName("typeName")]
    public string? TypeName { get; set; }
}
