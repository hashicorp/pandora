// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MobileAppRelationshipStateModel
{
    [JsonPropertyName("deviceId")]
    public string? DeviceId { get; set; }

    [JsonPropertyName("errorCode")]
    public int? ErrorCode { get; set; }

    [JsonPropertyName("installState")]
    public ResultantAppStateConstant? InstallState { get; set; }

    [JsonPropertyName("installStateDetail")]
    public ResultantAppStateDetailConstant? InstallStateDetail { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("sourceIds")]
    public List<string>? SourceIds { get; set; }

    [JsonPropertyName("targetDisplayName")]
    public string? TargetDisplayName { get; set; }

    [JsonPropertyName("targetId")]
    public string? TargetId { get; set; }

    [JsonPropertyName("targetLastSyncDateTime")]
    public DateTime? TargetLastSyncDateTime { get; set; }
}
