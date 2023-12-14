// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ReportSuspiciousActivitySettingsModel
{
    [JsonPropertyName("includeTarget")]
    public IncludeTargetModel? IncludeTarget { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("state")]
    public ReportSuspiciousActivitySettingsStateConstant? State { get; set; }

    [JsonPropertyName("voiceReportingCode")]
    public int? VoiceReportingCode { get; set; }
}
