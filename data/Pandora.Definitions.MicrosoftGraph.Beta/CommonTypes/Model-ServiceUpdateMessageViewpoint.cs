// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ServiceUpdateMessageViewpointModel
{
    [JsonPropertyName("isArchived")]
    public bool? IsArchived { get; set; }

    [JsonPropertyName("isFavorited")]
    public bool? IsFavorited { get; set; }

    [JsonPropertyName("isRead")]
    public bool? IsRead { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
