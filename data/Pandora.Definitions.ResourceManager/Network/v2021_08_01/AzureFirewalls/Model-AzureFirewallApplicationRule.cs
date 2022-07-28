using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.AzureFirewalls;


internal class AzureFirewallApplicationRuleModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("fqdnTags")]
    public List<string>? FqdnTags { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("protocols")]
    public List<AzureFirewallApplicationRuleProtocolModel>? Protocols { get; set; }

    [JsonPropertyName("sourceAddresses")]
    public List<string>? SourceAddresses { get; set; }

    [JsonPropertyName("sourceIpGroups")]
    public List<string>? SourceIPGroups { get; set; }

    [JsonPropertyName("targetFqdns")]
    public List<string>? TargetFqdns { get; set; }
}
