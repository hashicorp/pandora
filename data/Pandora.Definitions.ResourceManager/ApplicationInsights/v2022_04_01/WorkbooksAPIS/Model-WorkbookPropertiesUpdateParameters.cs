using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2022_04_01.WorkbooksAPIS;


internal class WorkbookPropertiesUpdateParametersModel
{
    [JsonPropertyName("category")]
    public string? Category { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("revision")]
    public string? Revision { get; set; }

    [JsonPropertyName("serializedData")]
    public string? SerializedData { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }
}
