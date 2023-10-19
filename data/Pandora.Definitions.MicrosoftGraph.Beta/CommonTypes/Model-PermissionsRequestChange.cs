// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PermissionsRequestChangeModel
{
    [JsonPropertyName("activeOccurrenceStatus")]
    public PermissionsRequestChangeActiveOccurrenceStatusConstant? ActiveOccurrenceStatus { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("modificationDateTime")]
    public DateTime? ModificationDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("permissionsRequestId")]
    public string? PermissionsRequestId { get; set; }

    [JsonPropertyName("statusDetail")]
    public PermissionsRequestChangeStatusDetailConstant? StatusDetail { get; set; }

    [JsonPropertyName("ticketId")]
    public string? TicketId { get; set; }
}
