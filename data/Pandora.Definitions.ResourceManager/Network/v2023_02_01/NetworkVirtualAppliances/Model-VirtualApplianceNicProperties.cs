using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.NetworkVirtualAppliances;


internal class VirtualApplianceNicPropertiesModel
{
    [JsonPropertyName("instanceName")]
    public string? InstanceName { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("privateIpAddress")]
    public string? PrivateIPAddress { get; set; }

    [JsonPropertyName("publicIpAddress")]
    public string? PublicIPAddress { get; set; }
}
