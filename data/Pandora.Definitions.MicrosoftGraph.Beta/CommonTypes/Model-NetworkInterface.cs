// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class NetworkInterfaceModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("ipV4Address")]
    public string? IpV4Address { get; set; }

    [JsonPropertyName("ipV6Address")]
    public string? IpV6Address { get; set; }

    [JsonPropertyName("localIpV6Address")]
    public string? LocalIpV6Address { get; set; }

    [JsonPropertyName("macAddress")]
    public string? MacAddress { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
