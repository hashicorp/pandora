// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MobileAppAssignmentModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("intent")]
    public MobileAppAssignmentIntentConstant? Intent { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("settings")]
    public MobileAppAssignmentSettingsModel? Settings { get; set; }

    [JsonPropertyName("source")]
    public MobileAppAssignmentSourceConstant? Source { get; set; }

    [JsonPropertyName("sourceId")]
    public string? SourceId { get; set; }

    [JsonPropertyName("target")]
    public DeviceAndAppManagementAssignmentTargetModel? Target { get; set; }
}
