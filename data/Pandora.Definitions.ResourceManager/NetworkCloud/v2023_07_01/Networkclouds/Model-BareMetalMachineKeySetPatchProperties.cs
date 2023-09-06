using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;


internal class BareMetalMachineKeySetPatchPropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("expiration")]
    public DateTime? Expiration { get; set; }

    [JsonPropertyName("jumpHostsAllowed")]
    public List<string>? JumpHostsAllowed { get; set; }

    [JsonPropertyName("userList")]
    public List<KeySetUserModel>? UserList { get; set; }
}
