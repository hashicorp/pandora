using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2020_11_20.WorkbookTemplatesAPIS;


internal class WorkbookTemplateGalleryModel
{
    [JsonPropertyName("category")]
    public string? Category { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("order")]
    public int? Order { get; set; }

    [JsonPropertyName("resourceType")]
    public string? ResourceType { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}
