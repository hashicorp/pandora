using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.NetworkSecurityGroups;


internal class NetworkInterfaceIPConfigurationPrivateLinkConnectionPropertiesModel
{
    [JsonPropertyName("fqdns")]
    public List<string>? Fqdns { get; set; }

    [JsonPropertyName("groupId")]
    public string? GroupId { get; set; }

    [JsonPropertyName("requiredMemberName")]
    public string? RequiredMemberName { get; set; }
}
