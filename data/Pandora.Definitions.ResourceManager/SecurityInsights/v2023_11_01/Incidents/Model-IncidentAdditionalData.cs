using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_11_01.Incidents;


internal class IncidentAdditionalDataModel
{
    [JsonPropertyName("alertProductNames")]
    public List<string>? AlertProductNames { get; set; }

    [JsonPropertyName("alertsCount")]
    public int? AlertsCount { get; set; }

    [JsonPropertyName("bookmarksCount")]
    public int? BookmarksCount { get; set; }

    [JsonPropertyName("commentsCount")]
    public int? CommentsCount { get; set; }

    [JsonPropertyName("providerIncidentUrl")]
    public string? ProviderIncidentUrl { get; set; }

    [JsonPropertyName("tactics")]
    public List<AttackTacticConstant>? Tactics { get; set; }
}
