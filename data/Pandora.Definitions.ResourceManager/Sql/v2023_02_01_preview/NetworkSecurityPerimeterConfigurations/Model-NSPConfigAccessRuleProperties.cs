using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.NetworkSecurityPerimeterConfigurations;


internal class NSPConfigAccessRulePropertiesModel
{
    [JsonPropertyName("addressPrefixes")]
    public List<string>? AddressPrefixes { get; set; }

    [JsonPropertyName("direction")]
    public string? Direction { get; set; }

    [JsonPropertyName("fullyQualifiedDomainNames")]
    public List<string>? FullyQualifiedDomainNames { get; set; }

    [JsonPropertyName("networkSecurityPerimeters")]
    public List<NSPConfigNetworkSecurityPerimeterRuleModel>? NetworkSecurityPerimeters { get; set; }

    [JsonPropertyName("subscriptions")]
    public List<string>? Subscriptions { get; set; }
}
