using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.NotificationChannels;


internal class NotificationChannelPropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdDate")]
    public DateTime? CreatedDate { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("emailRecipient")]
    public string? EmailRecipient { get; set; }

    [JsonPropertyName("events")]
    public List<EventModel>? Events { get; set; }

    [JsonPropertyName("notificationLocale")]
    public string? NotificationLocale { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("uniqueIdentifier")]
    public string? UniqueIdentifier { get; set; }

    [JsonPropertyName("webHookUrl")]
    public string? WebHookUrl { get; set; }
}
