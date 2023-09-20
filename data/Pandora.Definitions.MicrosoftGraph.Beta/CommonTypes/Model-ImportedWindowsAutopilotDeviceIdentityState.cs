// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ImportedWindowsAutopilotDeviceIdentityStateModel
{
    [JsonPropertyName("deviceErrorCode")]
    public int? DeviceErrorCode { get; set; }

    [JsonPropertyName("deviceErrorName")]
    public string? DeviceErrorName { get; set; }

    [JsonPropertyName("deviceImportStatus")]
    public ImportedWindowsAutopilotDeviceIdentityStateDeviceImportStatusConstant? DeviceImportStatus { get; set; }

    [JsonPropertyName("deviceRegistrationId")]
    public string? DeviceRegistrationId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
