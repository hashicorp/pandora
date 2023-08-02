// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class Windows10NetworkProxyServerModel
{
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("exceptions")]
    public List<string>? Exceptions { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("useForLocalAddresses")]
    public bool? UseForLocalAddresses { get; set; }
}
