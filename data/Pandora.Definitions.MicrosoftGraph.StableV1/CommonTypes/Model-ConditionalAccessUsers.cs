// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ConditionalAccessUsersModel
{
    [JsonPropertyName("excludeGroups")]
    public List<string>? ExcludeGroups { get; set; }

    [JsonPropertyName("excludeGuestsOrExternalUsers")]
    public ConditionalAccessGuestsOrExternalUsersModel? ExcludeGuestsOrExternalUsers { get; set; }

    [JsonPropertyName("excludeRoles")]
    public List<string>? ExcludeRoles { get; set; }

    [JsonPropertyName("excludeUsers")]
    public List<string>? ExcludeUsers { get; set; }

    [JsonPropertyName("includeGroups")]
    public List<string>? IncludeGroups { get; set; }

    [JsonPropertyName("includeGuestsOrExternalUsers")]
    public ConditionalAccessGuestsOrExternalUsersModel? IncludeGuestsOrExternalUsers { get; set; }

    [JsonPropertyName("includeRoles")]
    public List<string>? IncludeRoles { get; set; }

    [JsonPropertyName("includeUsers")]
    public List<string>? IncludeUsers { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
