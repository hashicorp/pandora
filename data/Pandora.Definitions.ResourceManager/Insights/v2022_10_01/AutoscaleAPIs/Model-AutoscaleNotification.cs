using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2022_10_01.AutoscaleAPIs;


internal class AutoscaleNotificationModel
{
    [JsonPropertyName("email")]
    public EmailNotificationModel? Email { get; set; }

    [JsonPropertyName("operation")]
    [Required]
    public OperationTypeConstant Operation { get; set; }

    [JsonPropertyName("webhooks")]
    public List<WebhookNotificationModel>? WebHooks { get; set; }
}
