using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Authorization.v2020_10_01.RoleManagementPolicies;


internal class RoleManagementPolicyRuleTargetModel
{
    [JsonPropertyName("caller")]
    public string? Caller { get; set; }

    [JsonPropertyName("enforcedSettings")]
    public List<string>? EnforcedSettings { get; set; }

    [JsonPropertyName("inheritableSettings")]
    public List<string>? InheritableSettings { get; set; }

    [JsonPropertyName("level")]
    public string? Level { get; set; }

    [JsonPropertyName("operations")]
    public List<string>? Operations { get; set; }

    [JsonPropertyName("targetObjects")]
    public List<string>? TargetObjects { get; set; }
}
