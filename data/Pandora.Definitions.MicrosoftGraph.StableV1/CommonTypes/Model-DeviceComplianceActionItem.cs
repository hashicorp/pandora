// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class DeviceComplianceActionItemModel
{
    [JsonPropertyName("actionType")]
    public DeviceComplianceActionTypeConstant? ActionType { get; set; }

    [JsonPropertyName("gracePeriodHours")]
    public int? GracePeriodHours { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("notificationMessageCCList")]
    public List<string>? NotificationMessageCCList { get; set; }

    [JsonPropertyName("notificationTemplateId")]
    public string? NotificationTemplateId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
