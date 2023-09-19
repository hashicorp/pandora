// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class B2cIdentityUserFlowModel
{
    [JsonPropertyName("apiConnectorConfiguration")]
    public UserFlowApiConnectorConfigurationModel? ApiConnectorConfiguration { get; set; }

    [JsonPropertyName("defaultLanguageTag")]
    public string? DefaultLanguageTag { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("identityProviders")]
    public List<IdentityProviderModel>? IdentityProviders { get; set; }

    [JsonPropertyName("isLanguageCustomizationEnabled")]
    public bool? IsLanguageCustomizationEnabled { get; set; }

    [JsonPropertyName("languages")]
    public List<UserFlowLanguageConfigurationModel>? Languages { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("userAttributeAssignments")]
    public List<IdentityUserFlowAttributeAssignmentModel>? UserAttributeAssignments { get; set; }

    [JsonPropertyName("userFlowIdentityProviders")]
    public List<IdentityProviderBaseModel>? UserFlowIdentityProviders { get; set; }

    [JsonPropertyName("userFlowType")]
    public B2cIdentityUserFlowUserFlowTypeConstant? UserFlowType { get; set; }
}
