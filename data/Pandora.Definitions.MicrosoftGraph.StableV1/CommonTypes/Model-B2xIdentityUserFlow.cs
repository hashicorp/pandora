// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class B2xIdentityUserFlowModel
{
    [JsonPropertyName("apiConnectorConfiguration")]
    public UserFlowApiConnectorConfigurationModel? ApiConnectorConfiguration { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("identityProviders")]
    public List<IdentityProviderModel>? IdentityProviders { get; set; }

    [JsonPropertyName("languages")]
    public List<UserFlowLanguageConfigurationModel>? Languages { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("userAttributeAssignments")]
    public List<IdentityUserFlowAttributeAssignmentModel>? UserAttributeAssignments { get; set; }

    [JsonPropertyName("userFlowIdentityProviders")]
    public List<IdentityProviderBaseModel>? UserFlowIdentityProviders { get; set; }

    [JsonPropertyName("userFlowType")]
    public UserFlowTypeConstant? UserFlowType { get; set; }
}
