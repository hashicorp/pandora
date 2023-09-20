// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class CallRecordsServiceUserAgentModel
{
    [JsonPropertyName("applicationVersion")]
    public string? ApplicationVersion { get; set; }

    [JsonPropertyName("headerValue")]
    public string? HeaderValue { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("role")]
    public CallRecordsServiceUserAgentRoleConstant? Role { get; set; }
}
