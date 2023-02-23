using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2022_09_01.NetAppAccounts;


internal class LdapSearchScopeOptModel
{
    [JsonPropertyName("groupDN")]
    public string? GroupDN { get; set; }

    [JsonPropertyName("groupMembershipFilter")]
    public string? GroupMembershipFilter { get; set; }

    [JsonPropertyName("userDN")]
    public string? UserDN { get; set; }
}
