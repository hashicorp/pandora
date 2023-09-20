// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class IdentityContainerModel
{
    [JsonPropertyName("apiConnectors")]
    public List<IdentityApiConnectorModel>? ApiConnectors { get; set; }

    [JsonPropertyName("b2xUserFlows")]
    public List<B2xIdentityUserFlowModel>? B2xUserFlows { get; set; }

    [JsonPropertyName("conditionalAccess")]
    public ConditionalAccessRootModel? ConditionalAccess { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("identityProviders")]
    public List<IdentityProviderBaseModel>? IdentityProviders { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("userFlowAttributes")]
    public List<IdentityUserFlowAttributeModel>? UserFlowAttributes { get; set; }
}
