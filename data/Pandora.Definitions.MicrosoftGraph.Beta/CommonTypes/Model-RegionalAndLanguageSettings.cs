// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class RegionalAndLanguageSettingsModel
{
    [JsonPropertyName("authoringLanguages")]
    public List<LocaleInfoModel>? AuthoringLanguages { get; set; }

    [JsonPropertyName("defaultDisplayLanguage")]
    public LocaleInfoModel? DefaultDisplayLanguage { get; set; }

    [JsonPropertyName("defaultRegionalFormat")]
    public LocaleInfoModel? DefaultRegionalFormat { get; set; }

    [JsonPropertyName("defaultSpeechInputLanguage")]
    public LocaleInfoModel? DefaultSpeechInputLanguage { get; set; }

    [JsonPropertyName("defaultTranslationLanguage")]
    public LocaleInfoModel? DefaultTranslationLanguage { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("regionalFormatOverrides")]
    public RegionalFormatOverridesModel? RegionalFormatOverrides { get; set; }

    [JsonPropertyName("translationPreferences")]
    public TranslationPreferencesModel? TranslationPreferences { get; set; }
}
