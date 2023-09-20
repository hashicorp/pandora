// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class UserSettingsModel
{
    [JsonPropertyName("contactMergeSuggestions")]
    public ContactMergeSuggestionsModel? ContactMergeSuggestions { get; set; }

    [JsonPropertyName("contributionToContentDiscoveryAsOrganizationDisabled")]
    public bool? ContributionToContentDiscoveryAsOrganizationDisabled { get; set; }

    [JsonPropertyName("contributionToContentDiscoveryDisabled")]
    public bool? ContributionToContentDiscoveryDisabled { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("itemInsights")]
    public UserInsightsSettingsModel? ItemInsights { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("regionalAndLanguageSettings")]
    public RegionalAndLanguageSettingsModel? RegionalAndLanguageSettings { get; set; }

    [JsonPropertyName("shiftPreferences")]
    public ShiftPreferencesModel? ShiftPreferences { get; set; }
}
