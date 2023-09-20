// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UserTeamworkModel
{
    [JsonPropertyName("associatedTeams")]
    public List<AssociatedTeamInfoModel>? AssociatedTeams { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("installedApps")]
    public List<UserScopeTeamsAppInstallationModel>? InstalledApps { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
