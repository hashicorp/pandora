// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class VirtualAppointmentModel
{
    [JsonPropertyName("appointmentClientJoinWebUrl")]
    public string? AppointmentClientJoinWebUrl { get; set; }

    [JsonPropertyName("appointmentClients")]
    public List<VirtualAppointmentUserModel>? AppointmentClients { get; set; }

    [JsonPropertyName("externalAppointmentId")]
    public string? ExternalAppointmentId { get; set; }

    [JsonPropertyName("externalAppointmentUrl")]
    public string? ExternalAppointmentUrl { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("settings")]
    public VirtualAppointmentSettingsModel? Settings { get; set; }
}
