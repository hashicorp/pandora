using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Redis.v2022_06_01.Redis;


internal class RedisFirewallRulePropertiesModel
{
    [JsonPropertyName("endIP")]
    [Required]
    public string EndIP { get; set; }

    [JsonPropertyName("startIP")]
    [Required]
    public string StartIP { get; set; }
}
