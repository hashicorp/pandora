using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_09_09.SessionHost;


internal class SessionHostPropertiesModel
{
    [JsonPropertyName("agentVersion")]
    public string? AgentVersion { get; set; }

    [JsonPropertyName("allowNewSession")]
    public bool? AllowNewSession { get; set; }

    [JsonPropertyName("assignedUser")]
    public string? AssignedUser { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastHeartBeat")]
    public DateTime? LastHeartBeat { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastUpdateTime")]
    public DateTime? LastUpdateTime { get; set; }

    [JsonPropertyName("objectId")]
    public string? ObjectId { get; set; }

    [JsonPropertyName("osVersion")]
    public string? OsVersion { get; set; }

    [JsonPropertyName("resourceId")]
    public string? ResourceId { get; set; }

    [JsonPropertyName("sessionHostHealthCheckResults")]
    public List<SessionHostHealthCheckReportModel>? SessionHostHealthCheckResults { get; set; }

    [JsonPropertyName("sessions")]
    public int? Sessions { get; set; }

    [JsonPropertyName("status")]
    public StatusConstant? Status { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("statusTimestamp")]
    public DateTime? StatusTimestamp { get; set; }

    [JsonPropertyName("sxSStackVersion")]
    public string? SxSStackVersion { get; set; }

    [JsonPropertyName("updateErrorMessage")]
    public string? UpdateErrorMessage { get; set; }

    [JsonPropertyName("updateState")]
    public UpdateStateConstant? UpdateState { get; set; }

    [JsonPropertyName("virtualMachineId")]
    public string? VirtualMachineId { get; set; }
}
