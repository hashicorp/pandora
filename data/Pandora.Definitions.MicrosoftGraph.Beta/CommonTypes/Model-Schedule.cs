// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ScheduleModel
{
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("offerShiftRequests")]
    public List<OfferShiftRequestModel>? OfferShiftRequests { get; set; }

    [JsonPropertyName("offerShiftRequestsEnabled")]
    public bool? OfferShiftRequestsEnabled { get; set; }

    [JsonPropertyName("openShiftChangeRequests")]
    public List<OpenShiftChangeRequestModel>? OpenShiftChangeRequests { get; set; }

    [JsonPropertyName("openShifts")]
    public List<OpenShiftModel>? OpenShifts { get; set; }

    [JsonPropertyName("openShiftsEnabled")]
    public bool? OpenShiftsEnabled { get; set; }

    [JsonPropertyName("provisionStatus")]
    public ScheduleProvisionStatusConstant? ProvisionStatus { get; set; }

    [JsonPropertyName("provisionStatusCode")]
    public string? ProvisionStatusCode { get; set; }

    [JsonPropertyName("schedulingGroups")]
    public List<SchedulingGroupModel>? SchedulingGroups { get; set; }

    [JsonPropertyName("shifts")]
    public List<ShiftModel>? Shifts { get; set; }

    [JsonPropertyName("swapShiftsChangeRequests")]
    public List<SwapShiftsChangeRequestModel>? SwapShiftsChangeRequests { get; set; }

    [JsonPropertyName("swapShiftsRequestsEnabled")]
    public bool? SwapShiftsRequestsEnabled { get; set; }

    [JsonPropertyName("timeCards")]
    public List<TimeCardModel>? TimeCards { get; set; }

    [JsonPropertyName("timeClockEnabled")]
    public bool? TimeClockEnabled { get; set; }

    [JsonPropertyName("timeClockSettings")]
    public TimeClockSettingsModel? TimeClockSettings { get; set; }

    [JsonPropertyName("timeOffReasons")]
    public List<TimeOffReasonModel>? TimeOffReasons { get; set; }

    [JsonPropertyName("timeOffRequests")]
    public List<TimeOffRequestModel>? TimeOffRequests { get; set; }

    [JsonPropertyName("timeOffRequestsEnabled")]
    public bool? TimeOffRequestsEnabled { get; set; }

    [JsonPropertyName("timeZone")]
    public string? TimeZone { get; set; }

    [JsonPropertyName("timesOff")]
    public List<TimeOffModel>? TimesOff { get; set; }

    [JsonPropertyName("workforceIntegrationIds")]
    public List<string>? WorkforceIntegrationIds { get; set; }
}
