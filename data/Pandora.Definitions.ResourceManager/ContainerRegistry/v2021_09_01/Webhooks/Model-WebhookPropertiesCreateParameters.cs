using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_09_01.Webhooks;


internal class WebhookPropertiesCreateParametersModel
{
    [JsonPropertyName("actions")]
    [Required]
    public List<WebhookActionConstant> Actions { get; set; }

    [JsonPropertyName("customHeaders")]
    public Dictionary<string, string>? CustomHeaders { get; set; }

    [JsonPropertyName("scope")]
    public string? Scope { get; set; }

    [JsonPropertyName("serviceUri")]
    [Required]
    public string ServiceUri { get; set; }

    [JsonPropertyName("status")]
    public WebhookStatusConstant? Status { get; set; }
}
