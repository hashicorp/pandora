using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AAD.v2021_05_01.DomainServices;


internal class ForestTrustModel
{
    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("remoteDnsIps")]
    public string? RemoteDnsIps { get; set; }

    [JsonPropertyName("trustDirection")]
    public string? TrustDirection { get; set; }

    [JsonPropertyName("trustPassword")]
    public string? TrustPassword { get; set; }

    [JsonPropertyName("trustedDomainFqdn")]
    public string? TrustedDomainFqdn { get; set; }
}
