// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ServiceAnnouncementModel
{
    [JsonPropertyName("healthOverviews")]
    public List<ServiceHealthModel>? HealthOverviews { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("issues")]
    public List<ServiceHealthIssueModel>? Issues { get; set; }

    [JsonPropertyName("messages")]
    public List<ServiceUpdateMessageModel>? Messages { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
