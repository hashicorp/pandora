// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class HasPayloadLinkResultItemModel
{
    [JsonPropertyName("error")]
    public string? Error { get; set; }

    [JsonPropertyName("hasLink")]
    public bool? HasLink { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("payloadId")]
    public string? PayloadId { get; set; }

    [JsonPropertyName("sources")]
    public List<DeviceAndAppManagementAssignmentSourceConstant>? Sources { get; set; }
}
