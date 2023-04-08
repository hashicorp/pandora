using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2017_08_01_preview.InformationProtectionPolicies;


internal class InformationProtectionKeywordModel
{
    [JsonPropertyName("canBeNumeric")]
    public bool? CanBeNumeric { get; set; }

    [JsonPropertyName("custom")]
    public bool? Custom { get; set; }

    [JsonPropertyName("excluded")]
    public bool? Excluded { get; set; }

    [JsonPropertyName("pattern")]
    public string? Pattern { get; set; }
}
