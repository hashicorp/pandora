using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataDog.v2021_03_01.ApiKey;


internal class DatadogApiKeyModel
{
    [JsonPropertyName("created")]
    public string? Created { get; set; }

    [JsonPropertyName("createdBy")]
    public string? CreatedBy { get; set; }

    [JsonPropertyName("key")]
    [Required]
    public string Key { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
