using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.ScheduledActions;


internal class ScheduledActionPropertiesModel
{
    [JsonPropertyName("displayName")]
    [Required]
    public string DisplayName { get; set; }

    [JsonPropertyName("fileDestination")]
    public FileDestinationModel? FileDestination { get; set; }

    [JsonPropertyName("notification")]
    [Required]
    public NotificationPropertiesModel Notification { get; set; }

    [JsonPropertyName("notificationEmail")]
    public string? NotificationEmail { get; set; }

    [JsonPropertyName("schedule")]
    [Required]
    public SchedulePropertiesModel Schedule { get; set; }

    [JsonPropertyName("scope")]
    public string? Scope { get; set; }

    [JsonPropertyName("status")]
    [Required]
    public ScheduledActionStatusConstant Status { get; set; }

    [JsonPropertyName("viewId")]
    [Required]
    public string ViewId { get; set; }
}
