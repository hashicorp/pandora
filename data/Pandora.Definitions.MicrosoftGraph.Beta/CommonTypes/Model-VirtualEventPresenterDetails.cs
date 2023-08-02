// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class VirtualEventPresenterDetailsModel
{
    [JsonPropertyName("bio")]
    public ItemBodyModel? Bio { get; set; }

    [JsonPropertyName("company")]
    public string? Company { get; set; }

    [JsonPropertyName("jobTitle")]
    public string? JobTitle { get; set; }

    [JsonPropertyName("linkedInProfileWebUrl")]
    public string? LinkedInProfileWebUrl { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("personalSiteWebUrl")]
    public string? PersonalSiteWebUrl { get; set; }

    [JsonPropertyName("twitterProfileWebUrl")]
    public string? TwitterProfileWebUrl { get; set; }
}
