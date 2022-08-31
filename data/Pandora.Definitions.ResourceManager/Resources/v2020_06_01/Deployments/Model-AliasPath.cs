using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2020_06_01.Deployments;


internal class AliasPathModel
{
    [JsonPropertyName("apiVersions")]
    public List<string>? ApiVersions { get; set; }

    [JsonPropertyName("metadata")]
    public AliasPathMetadataModel? Metadata { get; set; }

    [JsonPropertyName("path")]
    public string? Path { get; set; }

    [JsonPropertyName("pattern")]
    public AliasPatternModel? Pattern { get; set; }
}
