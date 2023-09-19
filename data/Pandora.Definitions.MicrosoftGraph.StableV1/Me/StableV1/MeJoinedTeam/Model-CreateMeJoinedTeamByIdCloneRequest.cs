// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeJoinedTeam;

internal class CreateMeJoinedTeamByIdCloneRequestModel
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
    public CreateMeJoinedTeamByIdCloneRequestPartsToCloneConstant? PartsToClone { get; set; }

    [JsonPropertyName("visibility")]
    public CreateMeJoinedTeamByIdCloneRequestVisibilityConstant? Visibility { get; set; }
}
