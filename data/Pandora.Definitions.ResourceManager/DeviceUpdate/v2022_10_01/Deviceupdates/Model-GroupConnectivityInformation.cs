using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DeviceUpdate.v2022_10_01.Deviceupdates;


internal class GroupConnectivityInformationModel
{
    [JsonPropertyName("customerVisibleFqdns")]
    public List<string>? CustomerVisibleFqdns { get; set; }

    [JsonPropertyName("groupId")]
    public string? GroupId { get; set; }

    [JsonPropertyName("internalFqdn")]
    public string? InternalFqdn { get; set; }

    [JsonPropertyName("memberName")]
    public string? MemberName { get; set; }

    [JsonPropertyName("privateLinkServiceArmRegion")]
    public string? PrivateLinkServiceArmRegion { get; set; }

    [JsonPropertyName("redirectMapId")]
    public string? RedirectMapId { get; set; }
}
