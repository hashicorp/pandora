// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SignInActivityModel
{
    [JsonPropertyName("lastNonInteractiveSignInDateTime")]
    public DateTime? LastNonInteractiveSignInDateTime { get; set; }

    [JsonPropertyName("lastNonInteractiveSignInRequestId")]
    public string? LastNonInteractiveSignInRequestId { get; set; }

    [JsonPropertyName("lastSignInDateTime")]
    public DateTime? LastSignInDateTime { get; set; }

    [JsonPropertyName("lastSignInRequestId")]
    public string? LastSignInRequestId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
