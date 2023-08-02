using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2023_05_01.Diagnostics;


internal class IPSecurityRestrictionRuleModel
{
    [JsonPropertyName("action")]
    [Required]
    public ActionConstant Action { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("ipAddressRange")]
    [Required]
    public string IPAddressRange { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }
}
