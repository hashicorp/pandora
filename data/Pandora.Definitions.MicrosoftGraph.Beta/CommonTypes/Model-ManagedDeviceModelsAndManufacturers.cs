// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ManagedDeviceModelsAndManufacturersModel
{
    [JsonPropertyName("deviceManufacturers")]
    public List<string>? DeviceManufacturers { get; set; }

    [JsonPropertyName("deviceModels")]
    public List<string>? DeviceModels { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
