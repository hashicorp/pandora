using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;


internal class WebSiteInstanceStatusPropertiesModel
{
    [JsonPropertyName("consoleUrl")]
    public string? ConsoleUrl { get; set; }

    [JsonPropertyName("containers")]
    public Dictionary<string, ContainerInfoModel>? Containers { get; set; }

    [JsonPropertyName("detectorUrl")]
    public string? DetectorUrl { get; set; }

    [JsonPropertyName("healthCheckUrl")]
    public string? HealthCheckUrl { get; set; }

    [JsonPropertyName("state")]
    public SiteRuntimeStateConstant? State { get; set; }

    [JsonPropertyName("statusUrl")]
    public string? StatusUrl { get; set; }
}
