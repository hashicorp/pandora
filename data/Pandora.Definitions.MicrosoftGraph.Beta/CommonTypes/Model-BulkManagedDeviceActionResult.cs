// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class BulkManagedDeviceActionResultModel
{
    [JsonPropertyName("failedDeviceIds")]
    public List<string>? FailedDeviceIds { get; set; }

    [JsonPropertyName("notFoundDeviceIds")]
    public List<string>? NotFoundDeviceIds { get; set; }

    [JsonPropertyName("notSupportedDeviceIds")]
    public List<string>? NotSupportedDeviceIds { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("successfulDeviceIds")]
    public List<string>? SuccessfulDeviceIds { get; set; }
}
