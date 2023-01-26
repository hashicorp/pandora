using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.BgpServiceCommunities;


internal class BGPCommunityModel
{
    [JsonPropertyName("communityName")]
    public string? CommunityName { get; set; }

    [JsonPropertyName("communityPrefixes")]
    public List<string>? CommunityPrefixes { get; set; }

    [JsonPropertyName("communityValue")]
    public string? CommunityValue { get; set; }

    [JsonPropertyName("isAuthorizedToUse")]
    public bool? IsAuthorizedToUse { get; set; }

    [JsonPropertyName("serviceGroup")]
    public string? ServiceGroup { get; set; }

    [JsonPropertyName("serviceSupportedRegion")]
    public string? ServiceSupportedRegion { get; set; }
}
