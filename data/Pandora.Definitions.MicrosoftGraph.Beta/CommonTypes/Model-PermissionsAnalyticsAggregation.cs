// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PermissionsAnalyticsAggregationModel
{
    [JsonPropertyName("aws")]
    public PermissionsAnalyticsModel? Aws { get; set; }

    [JsonPropertyName("azure")]
    public PermissionsAnalyticsModel? Azure { get; set; }

    [JsonPropertyName("gcp")]
    public PermissionsAnalyticsModel? Gcp { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
