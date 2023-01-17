using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.ServiceFabricSchedules;


internal class NotificationSettingsModel
{
    [JsonPropertyName("emailRecipient")]
    public string? EmailRecipient { get; set; }

    [JsonPropertyName("notificationLocale")]
    public string? NotificationLocale { get; set; }

    [JsonPropertyName("status")]
    public EnableStatusConstant? Status { get; set; }

    [JsonPropertyName("timeInMinutes")]
    public int? TimeInMinutes { get; set; }

    [JsonPropertyName("webhookUrl")]
    public string? WebhookUrl { get; set; }
}
