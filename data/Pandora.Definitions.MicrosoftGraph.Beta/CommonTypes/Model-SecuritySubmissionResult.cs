// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecuritySubmissionResultModel
{
    [JsonPropertyName("category")]
    public SubmissionResultCategoryConstant? Category { get; set; }

    [JsonPropertyName("detail")]
    public SubmissionResultDetailConstant? Detail { get; set; }

    [JsonPropertyName("detectedFiles")]
    public List<SubmissionDetectedFileModel>? DetectedFiles { get; set; }

    [JsonPropertyName("detectedUrls")]
    public List<string>? DetectedUrls { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("userMailboxSetting")]
    public UserMailboxSettingConstant? UserMailboxSetting { get; set; }
}
