// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class UserScopeTeamsAppInstallationModel
{
    [JsonPropertyName("chat")]
    public ChatModel? Chat { get; set; }

    [JsonPropertyName("consentedPermissionSet")]
    public TeamsAppPermissionSetModel? ConsentedPermissionSet { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("teamsApp")]
    public TeamsAppModel? TeamsApp { get; set; }

    [JsonPropertyName("teamsAppDefinition")]
    public TeamsAppDefinitionModel? TeamsAppDefinition { get; set; }
}
