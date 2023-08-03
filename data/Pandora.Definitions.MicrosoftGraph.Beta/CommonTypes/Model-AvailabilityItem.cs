// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AvailabilityItemModel
{
    [JsonPropertyName("endDateTime")]
    public DateTimeTimeZoneModel? EndDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("serviceId")]
    public string? ServiceId { get; set; }

    [JsonPropertyName("startDateTime")]
    public DateTimeTimeZoneModel? StartDateTime { get; set; }

    [JsonPropertyName("status")]
    public BookingsAvailabilityStatusConstant? Status { get; set; }
}
