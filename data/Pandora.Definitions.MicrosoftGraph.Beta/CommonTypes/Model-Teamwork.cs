// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TeamworkModel
{
    [JsonPropertyName("deletedChats")]
    public List<DeletedChatModel>? DeletedChats { get; set; }

    [JsonPropertyName("deletedTeams")]
    public List<DeletedTeamModel>? DeletedTeams { get; set; }

    [JsonPropertyName("devices")]
    public List<TeamworkDeviceModel>? Devices { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("teamTemplates")]
    public List<TeamTemplateModel>? TeamTemplates { get; set; }

    [JsonPropertyName("teamsAppSettings")]
    public TeamsAppSettingsModel? TeamsAppSettings { get; set; }

    [JsonPropertyName("workforceIntegrations")]
    public List<WorkforceIntegrationModel>? WorkforceIntegrations { get; set; }
}
