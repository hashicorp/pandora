using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SignalR.v2022_02_01.SignalR;


internal class UpstreamTemplateModel
{
    [JsonPropertyName("auth")]
    public UpstreamAuthSettingsModel? Auth { get; set; }

    [JsonPropertyName("categoryPattern")]
    public string? CategoryPattern { get; set; }

    [JsonPropertyName("eventPattern")]
    public string? EventPattern { get; set; }

    [JsonPropertyName("hubPattern")]
    public string? HubPattern { get; set; }

    [JsonPropertyName("urlTemplate")]
    [Required]
    public string UrlTemplate { get; set; }
}
