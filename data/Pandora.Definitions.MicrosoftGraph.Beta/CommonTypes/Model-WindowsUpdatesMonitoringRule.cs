// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsUpdatesMonitoringRuleModel
{
    [JsonPropertyName("action")]
    public MonitoringActionConstant? Action { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("signal")]
    public MonitoringSignalConstant? Signal { get; set; }

    [JsonPropertyName("threshold")]
    public int? Threshold { get; set; }
}
