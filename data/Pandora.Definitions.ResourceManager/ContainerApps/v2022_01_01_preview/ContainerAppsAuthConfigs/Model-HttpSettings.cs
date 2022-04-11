using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsAuthConfigs;


internal class HttpSettingsModel
{
    [JsonPropertyName("forwardProxy")]
    public ForwardProxyModel? ForwardProxy { get; set; }

    [JsonPropertyName("requireHttps")]
    public bool? RequireHttps { get; set; }

    [JsonPropertyName("routes")]
    public HttpSettingsRoutesModel? Routes { get; set; }
}
