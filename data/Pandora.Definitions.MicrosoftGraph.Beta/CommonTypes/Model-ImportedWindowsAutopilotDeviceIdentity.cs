// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ImportedWindowsAutopilotDeviceIdentityModel
{
    [JsonPropertyName("assignedUserPrincipalName")]
    public string? AssignedUserPrincipalName { get; set; }

    [JsonPropertyName("groupTag")]
    public string? GroupTag { get; set; }

    [JsonPropertyName("hardwareIdentifier")]
    public string? HardwareIdentifier { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("importId")]
    public string? ImportId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("productKey")]
    public string? ProductKey { get; set; }

    [JsonPropertyName("serialNumber")]
    public string? SerialNumber { get; set; }

    [JsonPropertyName("state")]
    public ImportedWindowsAutopilotDeviceIdentityStateModel? State { get; set; }
}
