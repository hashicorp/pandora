// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ZebraFotaDeploymentStatusModel
{
    [JsonPropertyName("cancelRequested")]
    public bool? CancelRequested { get; set; }

    [JsonPropertyName("completeOrCanceledDateTime")]
    public DateTime? CompleteOrCanceledDateTime { get; set; }

    [JsonPropertyName("errorCode")]
    public ZebraFotaErrorCodeConstant? ErrorCode { get; set; }

    [JsonPropertyName("lastUpdatedDateTime")]
    public DateTime? LastUpdatedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("state")]
    public ZebraFotaDeploymentStateConstant? State { get; set; }

    [JsonPropertyName("totalAwaitingInstall")]
    public int? TotalAwaitingInstall { get; set; }

    [JsonPropertyName("totalCanceled")]
    public int? TotalCanceled { get; set; }

    [JsonPropertyName("totalCreated")]
    public int? TotalCreated { get; set; }

    [JsonPropertyName("totalDevices")]
    public int? TotalDevices { get; set; }

    [JsonPropertyName("totalDownloading")]
    public int? TotalDownloading { get; set; }

    [JsonPropertyName("totalFailedDownload")]
    public int? TotalFailedDownload { get; set; }

    [JsonPropertyName("totalFailedInstall")]
    public int? TotalFailedInstall { get; set; }

    [JsonPropertyName("totalScheduled")]
    public int? TotalScheduled { get; set; }

    [JsonPropertyName("totalSucceededInstall")]
    public int? TotalSucceededInstall { get; set; }

    [JsonPropertyName("totalUnknown")]
    public int? TotalUnknown { get; set; }
}
