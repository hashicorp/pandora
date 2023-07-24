using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.Diagnostics;


internal class SolutionModel
{
    [JsonPropertyName("data")]
    public List<List<NameValuePairModel>>? Data { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public float? Id { get; set; }

    [JsonPropertyName("metadata")]
    public List<List<NameValuePairModel>>? Metadata { get; set; }

    [JsonPropertyName("order")]
    public float? Order { get; set; }

    [JsonPropertyName("type")]
    public SolutionTypeConstant? Type { get; set; }
}
