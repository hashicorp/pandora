using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.StaticSites;


internal class StaticSiteZipDeploymentModel
{
    [JsonPropertyName("apiZipUrl")]
    public string? ApiZipUrl { get; set; }

    [JsonPropertyName("appZipUrl")]
    public string? AppZipUrl { get; set; }

    [JsonPropertyName("deploymentTitle")]
    public string? DeploymentTitle { get; set; }

    [JsonPropertyName("functionLanguage")]
    public string? FunctionLanguage { get; set; }

    [JsonPropertyName("provider")]
    public string? Provider { get; set; }
}
