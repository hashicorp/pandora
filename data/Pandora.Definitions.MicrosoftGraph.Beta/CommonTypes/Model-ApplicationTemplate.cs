// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ApplicationTemplateModel
{
    [JsonPropertyName("categories")]
    public List<string>? Categories { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("homePageUrl")]
    public string? HomePageUrl { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("informationalUrls")]
    public InformationalUrlsModel? InformationalUrls { get; set; }

    [JsonPropertyName("logoUrl")]
    public string? LogoUrl { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("publisher")]
    public string? Publisher { get; set; }

    [JsonPropertyName("supportedClaimConfiguration")]
    public SupportedClaimConfigurationModel? SupportedClaimConfiguration { get; set; }

    [JsonPropertyName("supportedProvisioningTypes")]
    public List<string>? SupportedProvisioningTypes { get; set; }

    [JsonPropertyName("supportedSingleSignOnModes")]
    public List<string>? SupportedSingleSignOnModes { get; set; }
}
