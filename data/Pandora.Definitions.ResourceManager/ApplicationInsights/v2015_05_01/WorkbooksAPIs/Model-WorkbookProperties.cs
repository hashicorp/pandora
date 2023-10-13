using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2015_05_01.WorkbooksAPIs;


internal class WorkbookPropertiesModel
{
    [JsonPropertyName("category")]
    [Required]
    public string Category { get; set; }

    [JsonPropertyName("kind")]
    [Required]
    public SharedTypeKindConstant Kind { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }

    [JsonPropertyName("serializedData")]
    [Required]
    public string SerializedData { get; set; }

    [JsonPropertyName("sourceResourceId")]
    public string? SourceResourceId { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    [JsonPropertyName("timeModified")]
    public string? TimeModified { get; set; }

    [JsonPropertyName("userId")]
    [Required]
    public string UserId { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }

    [JsonPropertyName("workbookId")]
    [Required]
    public string WorkbookId { get; set; }
}
