using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.AppServiceEnvironments;


internal class CloningInfoModel
{
    [JsonPropertyName("appSettingsOverrides")]
    public Dictionary<string, string>? AppSettingsOverrides { get; set; }

    [JsonPropertyName("cloneCustomHostNames")]
    public bool? CloneCustomHostNames { get; set; }

    [JsonPropertyName("cloneSourceControl")]
    public bool? CloneSourceControl { get; set; }

    [JsonPropertyName("configureLoadBalancing")]
    public bool? ConfigureLoadBalancing { get; set; }

    [JsonPropertyName("correlationId")]
    public string? CorrelationId { get; set; }

    [JsonPropertyName("hostingEnvironment")]
    public string? HostingEnvironment { get; set; }

    [JsonPropertyName("overwrite")]
    public bool? Overwrite { get; set; }

    [JsonPropertyName("sourceWebAppId")]
    [Required]
    public string SourceWebAppId { get; set; }

    [JsonPropertyName("sourceWebAppLocation")]
    public string? SourceWebAppLocation { get; set; }

    [JsonPropertyName("trafficManagerProfileId")]
    public string? TrafficManagerProfileId { get; set; }

    [JsonPropertyName("trafficManagerProfileName")]
    public string? TrafficManagerProfileName { get; set; }
}
