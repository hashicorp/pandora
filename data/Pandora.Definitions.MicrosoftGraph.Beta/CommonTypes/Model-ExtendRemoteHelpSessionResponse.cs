// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ExtendRemoteHelpSessionResponseModel
{
    [JsonPropertyName("acsHelperUserToken")]
    public string? AcsHelperUserToken { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("pubSubHelperAccessUri")]
    public string? PubSubHelperAccessUri { get; set; }

    [JsonPropertyName("sessionExpirationDateTime")]
    public DateTime? SessionExpirationDateTime { get; set; }

    [JsonPropertyName("sessionKey")]
    public string? SessionKey { get; set; }
}
