// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UnifiedRoleManagementPolicyRuleTargetModel
{
    [JsonPropertyName("caller")]
    public string? Caller { get; set; }

    [JsonPropertyName("enforcedSettings")]
    public List<string>? EnforcedSettings { get; set; }

    [JsonPropertyName("inheritableSettings")]
    public List<string>? InheritableSettings { get; set; }

    [JsonPropertyName("level")]
    public string? Level { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operations")]
    public List<string>? Operations { get; set; }

    [JsonPropertyName("targetObjects")]
    public List<DirectoryObjectModel>? TargetObjects { get; set; }
}
