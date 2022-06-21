using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Orbital.v2022_03_01.ContactProfile;


internal class EndPointModel
{
    [JsonPropertyName("endPointName")]
    [Required]
    public string EndPointName { get; set; }

    [JsonPropertyName("ipAddress")]
    [Required]
    public string IpAddress { get; set; }

    [JsonPropertyName("port")]
    [Required]
    public string Port { get; set; }

    [JsonPropertyName("protocol")]
    [Required]
    public ProtocolConstant Protocol { get; set; }
}
