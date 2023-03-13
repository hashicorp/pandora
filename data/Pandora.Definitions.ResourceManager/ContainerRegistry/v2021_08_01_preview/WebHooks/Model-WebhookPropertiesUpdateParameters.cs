using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_08_01_preview.WebHooks;


internal class WebhookPropertiesUpdateParametersModel
{
    [JsonPropertyName("actions")]
    public List<WebhookActionConstant>? Actions { get; set; }

    [JsonPropertyName("customHeaders")]
    public Dictionary<string, string>? CustomHeaders { get; set; }

    [JsonPropertyName("scope")]
    public string? Scope { get; set; }

    [JsonPropertyName("serviceUri")]
    public string? ServiceUri { get; set; }

    [JsonPropertyName("status")]
    public WebhookStatusConstant? Status { get; set; }
}
