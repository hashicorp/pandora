// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class TeleconferenceDeviceQualityModel
{
    [JsonPropertyName("callChainId")]
    public string? CallChainId { get; set; }

    [JsonPropertyName("cloudServiceDeploymentEnvironment")]
    public string? CloudServiceDeploymentEnvironment { get; set; }

    [JsonPropertyName("cloudServiceDeploymentId")]
    public string? CloudServiceDeploymentId { get; set; }

    [JsonPropertyName("cloudServiceInstanceName")]
    public string? CloudServiceInstanceName { get; set; }

    [JsonPropertyName("cloudServiceName")]
    public string? CloudServiceName { get; set; }

    [JsonPropertyName("deviceDescription")]
    public string? DeviceDescription { get; set; }

    [JsonPropertyName("deviceName")]
    public string? DeviceName { get; set; }

    [JsonPropertyName("mediaLegId")]
    public string? MediaLegId { get; set; }

    [JsonPropertyName("mediaQualityList")]
    public List<TeleconferenceDeviceMediaQualityModel>? MediaQualityList { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("participantId")]
    public string? ParticipantId { get; set; }
}
