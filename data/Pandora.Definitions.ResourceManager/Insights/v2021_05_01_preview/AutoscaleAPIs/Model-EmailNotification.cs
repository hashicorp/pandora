using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2021_05_01_preview.AutoscaleAPIs;


internal class EmailNotificationModel
{
    [JsonPropertyName("customEmails")]
    public List<string>? CustomEmails { get; set; }

    [JsonPropertyName("sendToSubscriptionAdministrator")]
    public bool? SendToSubscriptionAdministrator { get; set; }

    [JsonPropertyName("sendToSubscriptionCoAdministrators")]
    public bool? SendToSubscriptionCoAdministrators { get; set; }
}
