// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AppliedAuthenticationEventListenerModel
{
    [JsonPropertyName("eventType")]
    public AuthenticationEventTypeConstant? EventType { get; set; }

    [JsonPropertyName("executedListenerId")]
    public string? ExecutedListenerId { get; set; }

    [JsonPropertyName("handlerResult")]
    public AuthenticationEventHandlerResultModel? HandlerResult { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
