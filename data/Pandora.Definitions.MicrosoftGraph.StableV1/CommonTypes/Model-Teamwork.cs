// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class TeamworkModel
{
    [JsonPropertyName("deletedTeams")]
    public List<DeletedTeamModel>? DeletedTeams { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("teamsAppSettings")]
    public TeamsAppSettingsModel? TeamsAppSettings { get; set; }

    [JsonPropertyName("workforceIntegrations")]
    public List<WorkforceIntegrationModel>? WorkforceIntegrations { get; set; }
}
