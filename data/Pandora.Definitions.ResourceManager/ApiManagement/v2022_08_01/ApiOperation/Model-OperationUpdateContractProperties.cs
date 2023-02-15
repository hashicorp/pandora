using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.ApiOperation;


internal class OperationUpdateContractPropertiesModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("method")]
    public string? Method { get; set; }

    [JsonPropertyName("policies")]
    public string? Policies { get; set; }

    [JsonPropertyName("request")]
    public RequestContractModel? Request { get; set; }

    [JsonPropertyName("responses")]
    public List<ResponseContractModel>? Responses { get; set; }

    [JsonPropertyName("templateParameters")]
    public List<ParameterContractModel>? TemplateParameters { get; set; }

    [JsonPropertyName("urlTemplate")]
    public string? UrlTemplate { get; set; }
}
