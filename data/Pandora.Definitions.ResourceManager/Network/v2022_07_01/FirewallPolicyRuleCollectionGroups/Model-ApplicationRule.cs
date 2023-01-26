using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.FirewallPolicyRuleCollectionGroups;

[ValueForType("ApplicationRule")]
internal class ApplicationRuleModel : FirewallPolicyRuleModel
{
    [JsonPropertyName("destinationAddresses")]
    public List<string>? DestinationAddresses { get; set; }

    [JsonPropertyName("fqdnTags")]
    public List<string>? FqdnTags { get; set; }

    [JsonPropertyName("protocols")]
    public List<FirewallPolicyRuleApplicationProtocolModel>? Protocols { get; set; }

    [JsonPropertyName("sourceAddresses")]
    public List<string>? SourceAddresses { get; set; }

    [JsonPropertyName("sourceIpGroups")]
    public List<string>? SourceIPGroups { get; set; }

    [JsonPropertyName("targetFqdns")]
    public List<string>? TargetFqdns { get; set; }

    [JsonPropertyName("targetUrls")]
    public List<string>? TargetUrls { get; set; }

    [JsonPropertyName("terminateTLS")]
    public bool? TerminateTLS { get; set; }

    [JsonPropertyName("webCategories")]
    public List<string>? WebCategories { get; set; }
}
