// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MobileAppTroubleshootingAppStateHistoryModel
{
    [JsonPropertyName("actionType")]
    public MobileAppTroubleshootingAppStateHistoryActionTypeConstant? ActionType { get; set; }

    [JsonPropertyName("errorCode")]
    public string? ErrorCode { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("occurrenceDateTime")]
    public DateTime? OccurrenceDateTime { get; set; }

    [JsonPropertyName("runState")]
    public MobileAppTroubleshootingAppStateHistoryRunStateConstant? RunState { get; set; }

    [JsonPropertyName("troubleshootingErrorDetails")]
    public DeviceManagementTroubleshootingErrorDetailsModel? TroubleshootingErrorDetails { get; set; }
}
