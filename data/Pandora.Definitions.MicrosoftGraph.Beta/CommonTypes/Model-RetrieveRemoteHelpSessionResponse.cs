// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class RetrieveRemoteHelpSessionResponseModel
{
    [JsonPropertyName("acsGroupId")]
    public string? AcsGroupId { get; set; }

    [JsonPropertyName("acsHelperUserId")]
    public string? AcsHelperUserId { get; set; }

    [JsonPropertyName("acsHelperUserToken")]
    public string? AcsHelperUserToken { get; set; }

    [JsonPropertyName("acsSharerUserId")]
    public string? AcsSharerUserId { get; set; }

    [JsonPropertyName("deviceName")]
    public string? DeviceName { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("pubSubGroupId")]
    public string? PubSubGroupId { get; set; }

    [JsonPropertyName("pubSubHelperAccessUri")]
    public string? PubSubHelperAccessUri { get; set; }

    [JsonPropertyName("sessionExpirationDateTime")]
    public DateTime? SessionExpirationDateTime { get; set; }

    [JsonPropertyName("sessionKey")]
    public string? SessionKey { get; set; }
}
