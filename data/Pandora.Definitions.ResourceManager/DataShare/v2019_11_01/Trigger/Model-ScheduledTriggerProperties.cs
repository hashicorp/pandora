using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataShare.v2019_11_01.Trigger;


internal class ScheduledTriggerPropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("recurrenceInterval")]
    [Required]
    public RecurrenceIntervalConstant RecurrenceInterval { get; set; }

    [JsonPropertyName("synchronizationMode")]
    public SynchronizationModeConstant? SynchronizationMode { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("synchronizationTime")]
    [Required]
    public DateTime SynchronizationTime { get; set; }

    [JsonPropertyName("triggerStatus")]
    public TriggerStatusConstant? TriggerStatus { get; set; }

    [JsonPropertyName("userName")]
    public string? UserName { get; set; }
}
