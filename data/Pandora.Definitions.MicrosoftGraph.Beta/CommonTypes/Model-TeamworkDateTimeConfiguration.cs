// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TeamworkDateTimeConfigurationModel
{
    [JsonPropertyName("dateFormat")]
    public string? DateFormat { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("officeHoursEndTime")]
    public DateTime? OfficeHoursEndTime { get; set; }

    [JsonPropertyName("officeHoursStartTime")]
    public DateTime? OfficeHoursStartTime { get; set; }

    [JsonPropertyName("timeFormat")]
    public string? TimeFormat { get; set; }

    [JsonPropertyName("timeZone")]
    public string? TimeZone { get; set; }
}
