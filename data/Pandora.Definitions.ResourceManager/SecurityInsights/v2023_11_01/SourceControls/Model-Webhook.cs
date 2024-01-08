using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_11_01.SourceControls;


internal class WebhookModel
{
    [JsonPropertyName("rotateWebhookSecret")]
    public bool? RotateWebhookSecret { get; set; }

    [JsonPropertyName("webhookId")]
    public string? WebhookId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("webhookSecretUpdateTime")]
    public DateTime? WebhookSecretUpdateTime { get; set; }

    [JsonPropertyName("webhookUrl")]
    public string? WebhookUrl { get; set; }
}
