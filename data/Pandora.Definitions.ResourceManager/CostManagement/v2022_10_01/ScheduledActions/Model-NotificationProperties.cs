using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.ScheduledActions;


internal class NotificationPropertiesModel
{
    [JsonPropertyName("language")]
    public string? Language { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("regionalFormat")]
    public string? RegionalFormat { get; set; }

    [JsonPropertyName("subject")]
    [Required]
    public string Subject { get; set; }

    [MinItems(1)]
    [MaxItems(20)]
    [JsonPropertyName("to")]
    [Required]
    public List<string> To { get; set; }
}
