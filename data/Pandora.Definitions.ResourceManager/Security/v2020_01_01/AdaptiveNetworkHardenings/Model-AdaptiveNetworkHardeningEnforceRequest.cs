using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.AdaptiveNetworkHardenings;


internal class AdaptiveNetworkHardeningEnforceRequestModel
{
    [JsonPropertyName("networkSecurityGroups")]
    [Required]
    public List<string> NetworkSecurityGroups { get; set; }

    [JsonPropertyName("rules")]
    [Required]
    public List<RuleModel> Rules { get; set; }
}
