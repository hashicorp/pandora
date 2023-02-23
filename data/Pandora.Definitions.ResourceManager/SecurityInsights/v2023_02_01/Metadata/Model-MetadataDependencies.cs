using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_02_01.Metadata;


internal class MetadataDependenciesModel
{
    [JsonPropertyName("contentId")]
    public string? ContentId { get; set; }

    [JsonPropertyName("criteria")]
    public List<MetadataDependenciesModel>? Criteria { get; set; }

    [JsonPropertyName("kind")]
    public string? Kind { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("operator")]
    public OperatorConstant? Operator { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
