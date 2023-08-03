// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsAutopilotSettingsModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastManualSyncTriggerDateTime")]
    public DateTime? LastManualSyncTriggerDateTime { get; set; }

    [JsonPropertyName("lastSyncDateTime")]
    public DateTime? LastSyncDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("syncStatus")]
    public WindowsAutopilotSyncStatusConstant? SyncStatus { get; set; }
}
