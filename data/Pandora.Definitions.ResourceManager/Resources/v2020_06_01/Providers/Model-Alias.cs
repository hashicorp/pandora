using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2020_06_01.Providers;


internal class AliasModel
{
    [JsonPropertyName("defaultMetadata")]
    public AliasPathMetadataModel? DefaultMetadata { get; set; }

    [JsonPropertyName("defaultPath")]
    public string? DefaultPath { get; set; }

    [JsonPropertyName("defaultPattern")]
    public AliasPatternModel? DefaultPattern { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("paths")]
    public List<AliasPathModel>? Paths { get; set; }

    [JsonPropertyName("type")]
    public AliasTypeConstant? Type { get; set; }
}
