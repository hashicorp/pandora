using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServices.v2021_08_01.Vaults;


internal class UpgradeDetailsModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endTimeUtc")]
    public DateTime? EndTimeUtc { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastUpdatedTimeUtc")]
    public DateTime? LastUpdatedTimeUtc { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("operationId")]
    public string? OperationId { get; set; }

    [JsonPropertyName("previousResourceId")]
    public string? PreviousResourceId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTimeUtc")]
    public DateTime? StartTimeUtc { get; set; }

    [JsonPropertyName("status")]
    public VaultUpgradeStateConstant? Status { get; set; }

    [JsonPropertyName("triggerType")]
    public TriggerTypeConstant? TriggerType { get; set; }

    [JsonPropertyName("upgradedResourceId")]
    public string? UpgradedResourceId { get; set; }
}
