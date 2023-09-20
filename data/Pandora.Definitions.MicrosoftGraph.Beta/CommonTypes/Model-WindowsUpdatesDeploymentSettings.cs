// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsUpdatesDeploymentSettingsModel
{
    [JsonPropertyName("contentApplicability")]
    public WindowsUpdatesContentApplicabilitySettingsModel? ContentApplicability { get; set; }

    [JsonPropertyName("expedite")]
    public WindowsUpdatesExpediteSettingsModel? Expedite { get; set; }

    [JsonPropertyName("monitoring")]
    public WindowsUpdatesMonitoringSettingsModel? Monitoring { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("schedule")]
    public WindowsUpdatesScheduleSettingsModel? Schedule { get; set; }

    [JsonPropertyName("userExperience")]
    public WindowsUpdatesUserExperienceSettingsModel? UserExperience { get; set; }
}
