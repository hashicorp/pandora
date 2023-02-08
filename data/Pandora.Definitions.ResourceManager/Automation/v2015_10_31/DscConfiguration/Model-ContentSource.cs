using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2015_10_31.DscConfiguration;


internal class ContentSourceModel
{
    [JsonPropertyName("hash")]
    public ContentHashModel? Hash { get; set; }

    [JsonPropertyName("type")]
    public ContentSourceTypeConstant? Type { get; set; }

    [JsonPropertyName("value")]
    public string? Value { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
