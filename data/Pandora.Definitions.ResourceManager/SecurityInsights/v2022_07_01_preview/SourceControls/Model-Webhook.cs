using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.SourceControls;


internal class WebhookModel
{
    [JsonPropertyName("rotateWebhookSecret")]
    public bool? RotateWebhookSecret { get; set; }

    [JsonPropertyName("webhookId")]
    public string? WebhookId { get; set; }

    [JsonPropertyName("webhookSecretUpdateTime")]
    public string? WebhookSecretUpdateTime { get; set; }

    [JsonPropertyName("webhookUrl")]
    public string? WebhookUrl { get; set; }
}
