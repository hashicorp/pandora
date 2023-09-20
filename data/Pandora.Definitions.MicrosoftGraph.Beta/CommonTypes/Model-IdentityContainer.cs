// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class IdentityContainerModel
{
    [JsonPropertyName("apiConnectors")]
    public List<IdentityApiConnectorModel>? ApiConnectors { get; set; }

    [JsonPropertyName("authenticationEventListeners")]
    public List<AuthenticationEventListenerModel>? AuthenticationEventListeners { get; set; }

    [JsonPropertyName("authenticationEventsFlows")]
    public List<AuthenticationEventsFlowModel>? AuthenticationEventsFlows { get; set; }

    [JsonPropertyName("b2cUserFlows")]
    public List<B2cIdentityUserFlowModel>? B2cUserFlows { get; set; }

    [JsonPropertyName("b2xUserFlows")]
    public List<B2xIdentityUserFlowModel>? B2xUserFlows { get; set; }

    [JsonPropertyName("conditionalAccess")]
    public ConditionalAccessRootModel? ConditionalAccess { get; set; }

    [JsonPropertyName("continuousAccessEvaluationPolicy")]
    public ContinuousAccessEvaluationPolicyModel? ContinuousAccessEvaluationPolicy { get; set; }

    [JsonPropertyName("customAuthenticationExtensions")]
    public List<CustomAuthenticationExtensionModel>? CustomAuthenticationExtensions { get; set; }

    [JsonPropertyName("identityProviders")]
    public List<IdentityProviderBaseModel>? IdentityProviders { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("userFlowAttributes")]
    public List<IdentityUserFlowAttributeModel>? UserFlowAttributes { get; set; }

    [JsonPropertyName("userFlows")]
    public List<IdentityUserFlowModel>? UserFlows { get; set; }
}
