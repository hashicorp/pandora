using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2020_10_01.Deployments;


internal class AliasPatternModel
{
    [JsonPropertyName("phrase")]
    public string? Phrase { get; set; }

    [JsonPropertyName("type")]
    public AliasPatternTypeConstant? Type { get; set; }

    [JsonPropertyName("variable")]
    public string? Variable { get; set; }
}
