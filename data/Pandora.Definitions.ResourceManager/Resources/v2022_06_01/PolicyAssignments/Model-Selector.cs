using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2022_06_01.PolicyAssignments;


internal class SelectorModel
{
    [JsonPropertyName("in")]
    public List<string>? In { get; set; }

    [JsonPropertyName("kind")]
    public SelectorKindConstant? Kind { get; set; }

    [JsonPropertyName("notIn")]
    public List<string>? NotIn { get; set; }
}
