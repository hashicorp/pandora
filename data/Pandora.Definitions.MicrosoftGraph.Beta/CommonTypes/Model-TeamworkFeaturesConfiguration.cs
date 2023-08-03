// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TeamworkFeaturesConfigurationModel
{
    [JsonPropertyName("emailToSendLogsAndFeedback")]
    public string? EmailToSendLogsAndFeedback { get; set; }

    [JsonPropertyName("isAutoScreenShareEnabled")]
    public bool? IsAutoScreenShareEnabled { get; set; }

    [JsonPropertyName("isBluetoothBeaconingEnabled")]
    public bool? IsBluetoothBeaconingEnabled { get; set; }

    [JsonPropertyName("isHideMeetingNamesEnabled")]
    public bool? IsHideMeetingNamesEnabled { get; set; }

    [JsonPropertyName("isSendLogsAndFeedbackEnabled")]
    public bool? IsSendLogsAndFeedbackEnabled { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
