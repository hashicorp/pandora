// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TeamsTabModel
{
    [JsonPropertyName("configuration")]
    public TeamsTabConfigurationModel? Configuration { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("messageId")]
    public string? MessageId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("sortOrderIndex")]
    public string? SortOrderIndex { get; set; }

    [JsonPropertyName("teamsApp")]
    public TeamsAppModel? TeamsApp { get; set; }

    [JsonPropertyName("teamsAppId")]
    public string? TeamsAppId { get; set; }

    [JsonPropertyName("webUrl")]
    public string? WebUrl { get; set; }
}
