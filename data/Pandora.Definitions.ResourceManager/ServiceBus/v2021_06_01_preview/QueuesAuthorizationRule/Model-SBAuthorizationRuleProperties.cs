using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceBus.v2021_06_01_preview.QueuesAuthorizationRule;


internal class SBAuthorizationRulePropertiesModel
{
    [JsonPropertyName("rights")]
    [Required]
    public List<AccessRightsConstant> Rights { get; set; }
}
