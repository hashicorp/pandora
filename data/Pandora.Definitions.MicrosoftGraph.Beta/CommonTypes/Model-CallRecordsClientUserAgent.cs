// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CallRecordsClientUserAgentModel
{
    [JsonPropertyName("applicationVersion")]
    public string? ApplicationVersion { get; set; }

    [JsonPropertyName("azureADAppId")]
    public string? AzureADAppId { get; set; }

    [JsonPropertyName("communicationServiceId")]
    public string? CommunicationServiceId { get; set; }

    [JsonPropertyName("headerValue")]
    public string? HeaderValue { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("platform")]
    public ClientPlatformConstant? Platform { get; set; }

    [JsonPropertyName("productFamily")]
    public ProductFamilyConstant? ProductFamily { get; set; }
}
