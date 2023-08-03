// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DeploymentSettingsModel
{
    [JsonPropertyName("contentApplicability")]
    public ContentApplicabilitySettingsModel? ContentApplicability { get; set; }

    [JsonPropertyName("expedite")]
    public ExpediteSettingsModel? Expedite { get; set; }

    [JsonPropertyName("monitoring")]
    public MonitoringSettingsModel? Monitoring { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("schedule")]
    public ScheduleSettingsModel? Schedule { get; set; }

    [JsonPropertyName("userExperience")]
    public UserExperienceSettingsModel? UserExperience { get; set; }
}
