// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ScheduledPermissionsRequestModel
{
    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("justification")]
    public string? Justification { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("requestedPermissions")]
    public PermissionsDefinitionModel? RequestedPermissions { get; set; }

    [JsonPropertyName("scheduleInfo")]
    public RequestScheduleModel? ScheduleInfo { get; set; }

    [JsonPropertyName("statusDetail")]
    public ScheduledPermissionsRequestStatusDetailConstant? StatusDetail { get; set; }

    [JsonPropertyName("ticketInfo")]
    public TicketInfoModel? TicketInfo { get; set; }
}
