using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Authorization.v2022_04_01.DenyAssignments;


internal class DenyAssignmentPermissionModel
{
    [JsonPropertyName("actions")]
    public List<string>? Actions { get; set; }

    [JsonPropertyName("condition")]
    public string? Condition { get; set; }

    [JsonPropertyName("conditionVersion")]
    public string? ConditionVersion { get; set; }

    [JsonPropertyName("dataActions")]
    public List<string>? DataActions { get; set; }

    [JsonPropertyName("notActions")]
    public List<string>? NotActions { get; set; }

    [JsonPropertyName("notDataActions")]
    public List<string>? NotDataActions { get; set; }
}
