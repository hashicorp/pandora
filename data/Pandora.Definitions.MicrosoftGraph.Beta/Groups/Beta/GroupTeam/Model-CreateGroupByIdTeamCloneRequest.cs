// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupTeam;

internal class CreateGroupByIdTeamCloneRequestModel
{
    [JsonPropertyName("classification")]
    public string? Classification { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("mailNickname")]
    public string? MailNickname { get; set; }

    [JsonPropertyName("partsToClone")]
    public CreateGroupByIdTeamCloneRequestPartsToCloneConstant? PartsToClone { get; set; }

    [JsonPropertyName("visibility")]
    public CreateGroupByIdTeamCloneRequestVisibilityConstant? Visibility { get; set; }
}
