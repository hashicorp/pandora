// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ServiceHealthModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("issues")]
    public List<ServiceHealthIssueModel>? Issues { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("service")]
    public string? Service { get; set; }

    [JsonPropertyName("status")]
    public ServiceHealthStatusConstant? Status { get; set; }
}
