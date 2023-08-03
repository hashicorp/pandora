// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ConnectorModel
{
    [JsonPropertyName("externalIp")]
    public string? ExternalIp { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("machineName")]
    public string? MachineName { get; set; }

    [JsonPropertyName("memberOf")]
    public List<ConnectorGroupModel>? MemberOf { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("status")]
    public ConnectorStatusConstant? Status { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
