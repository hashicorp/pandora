// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class EducationPowerSchoolDataProviderModel
{
    [JsonPropertyName("allowTeachersInMultipleSchools")]
    public bool? AllowTeachersInMultipleSchools { get; set; }

    [JsonPropertyName("clientId")]
    public string? ClientId { get; set; }

    [JsonPropertyName("clientSecret")]
    public string? ClientSecret { get; set; }

    [JsonPropertyName("connectionUrl")]
    public string? ConnectionUrl { get; set; }

    [JsonPropertyName("customizations")]
    public EducationSynchronizationCustomizationsModel? Customizations { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("schoolYear")]
    public string? SchoolYear { get; set; }

    [JsonPropertyName("schoolsIds")]
    public List<string>? SchoolsIds { get; set; }
}
