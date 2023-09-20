// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserJoinedTeam;

internal class CreateUserByIdJoinedTeamByIdCloneRequestModel
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
    public CreateUserByIdJoinedTeamByIdCloneRequestPartsToCloneConstant? PartsToClone { get; set; }

    [JsonPropertyName("visibility")]
    public CreateUserByIdJoinedTeamByIdCloneRequestVisibilityConstant? Visibility { get; set; }
}
