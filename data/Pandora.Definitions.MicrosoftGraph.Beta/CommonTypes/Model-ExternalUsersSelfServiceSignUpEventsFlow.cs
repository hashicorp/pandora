// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ExternalUsersSelfServiceSignUpEventsFlowModel
{
    [JsonPropertyName("conditions")]
    public AuthenticationConditionsModel? Conditions { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("onAttributeCollection")]
    public OnAttributeCollectionHandlerModel? OnAttributeCollection { get; set; }

    [JsonPropertyName("onAuthenticationMethodLoadStart")]
    public OnAuthenticationMethodLoadStartHandlerModel? OnAuthenticationMethodLoadStart { get; set; }

    [JsonPropertyName("onInteractiveAuthFlowStart")]
    public OnInteractiveAuthFlowStartHandlerModel? OnInteractiveAuthFlowStart { get; set; }

    [JsonPropertyName("onUserCreateStart")]
    public OnUserCreateStartHandlerModel? OnUserCreateStart { get; set; }

    [JsonPropertyName("priority")]
    public int? Priority { get; set; }
}
