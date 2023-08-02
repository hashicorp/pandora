// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class OnAttributeCollectionListenerModel
{
    [JsonPropertyName("authenticationEventsFlowId")]
    public string? AuthenticationEventsFlowId { get; set; }

    [JsonPropertyName("conditions")]
    public AuthenticationConditionsModel? Conditions { get; set; }

    [JsonPropertyName("handler")]
    public OnAttributeCollectionHandlerModel? Handler { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("priority")]
    public int? Priority { get; set; }
}
