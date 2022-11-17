using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2022_10_01.BatchAccount;


internal class IPRuleModel
{
    [JsonPropertyName("action")]
    [Required]
    public IPRuleActionConstant Action { get; set; }

    [JsonPropertyName("value")]
    [Required]
    public string Value { get; set; }
}
