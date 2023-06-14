using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.VirtualNetworkTap;


internal class PublicIPAddressDnsSettingsModel
{
    [JsonPropertyName("domainNameLabel")]
    public string? DomainNameLabel { get; set; }

    [JsonPropertyName("domainNameLabelScope")]
    public PublicIPAddressDnsSettingsDomainNameLabelScopeConstant? DomainNameLabelScope { get; set; }

    [JsonPropertyName("fqdn")]
    public string? Fqdn { get; set; }

    [JsonPropertyName("reverseFqdn")]
    public string? ReverseFqdn { get; set; }
}
