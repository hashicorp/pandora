// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ImportedWindowsAutopilotDeviceIdentityUploadModel
{
    [JsonPropertyName("createdDateTimeUtc")]
    public DateTime? CreatedDateTimeUtc { get; set; }

    [JsonPropertyName("deviceIdentities")]
    public List<ImportedWindowsAutopilotDeviceIdentityModel>? DeviceIdentities { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("status")]
    public ImportedWindowsAutopilotDeviceIdentityUploadStatusConstant? Status { get; set; }
}
