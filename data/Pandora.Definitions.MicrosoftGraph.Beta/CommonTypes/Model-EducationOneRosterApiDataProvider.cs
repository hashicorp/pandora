// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class EducationOneRosterApiDataProviderModel
{
    [JsonPropertyName("connectionSettings")]
    public EducationSynchronizationConnectionSettingsModel? ConnectionSettings { get; set; }

    [JsonPropertyName("connectionUrl")]
    public string? ConnectionUrl { get; set; }

    [JsonPropertyName("customizations")]
    public EducationSynchronizationCustomizationsModel? Customizations { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("providerName")]
    public string? ProviderName { get; set; }

    [JsonPropertyName("schoolsIds")]
    public List<string>? SchoolsIds { get; set; }

    [JsonPropertyName("termIds")]
    public List<string>? TermIds { get; set; }
}
