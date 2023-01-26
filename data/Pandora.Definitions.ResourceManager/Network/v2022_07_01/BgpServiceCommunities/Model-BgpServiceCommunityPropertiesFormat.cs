using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.BgpServiceCommunities;


internal class BgpServiceCommunityPropertiesFormatModel
{
    [JsonPropertyName("bgpCommunities")]
    public List<BGPCommunityModel>? BgpCommunities { get; set; }

    [JsonPropertyName("serviceName")]
    public string? ServiceName { get; set; }
}
