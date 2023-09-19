// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CloudPCRemoteActionResultModel
{
    [JsonPropertyName("actionName")]
    public string? ActionName { get; set; }

    [JsonPropertyName("actionState")]
    public CloudPCRemoteActionResultActionStateConstant? ActionState { get; set; }

    [JsonPropertyName("cloudPcId")]
    public string? CloudPCId { get; set; }

    [JsonPropertyName("lastUpdatedDateTime")]
    public DateTime? LastUpdatedDateTime { get; set; }

    [JsonPropertyName("managedDeviceId")]
    public string? ManagedDeviceId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("startDateTime")]
    public DateTime? StartDateTime { get; set; }

    [JsonPropertyName("statusDetails")]
    public CloudPCStatusDetailsModel? StatusDetails { get; set; }
}
