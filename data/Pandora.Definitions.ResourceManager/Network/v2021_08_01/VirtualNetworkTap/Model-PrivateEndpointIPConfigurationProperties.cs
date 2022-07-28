using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.VirtualNetworkTap;


internal class PrivateEndpointIPConfigurationPropertiesModel
{
    [JsonPropertyName("groupId")]
    public string? GroupId { get; set; }

    [JsonPropertyName("memberName")]
    public string? MemberName { get; set; }

    [JsonPropertyName("privateIPAddress")]
    public string? PrivateIPAddress { get; set; }
}
