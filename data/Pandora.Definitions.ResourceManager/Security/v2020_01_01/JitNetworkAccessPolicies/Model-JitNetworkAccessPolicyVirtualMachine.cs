using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.JitNetworkAccessPolicies;


internal class JitNetworkAccessPolicyVirtualMachineModel
{
    [JsonPropertyName("id")]
    [Required]
    public string Id { get; set; }

    [JsonPropertyName("ports")]
    [Required]
    public List<JitNetworkAccessPortRuleModel> Ports { get; set; }

    [JsonPropertyName("publicIpAddress")]
    public string? PublicIPAddress { get; set; }
}
