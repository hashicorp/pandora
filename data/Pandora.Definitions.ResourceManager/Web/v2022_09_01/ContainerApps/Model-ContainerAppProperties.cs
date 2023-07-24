using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.ContainerApps;


internal class ContainerAppPropertiesModel
{
    [JsonPropertyName("configuration")]
    public ConfigurationModel? Configuration { get; set; }

    [JsonPropertyName("kubeEnvironmentId")]
    public string? KubeEnvironmentId { get; set; }

    [JsonPropertyName("latestRevisionFqdn")]
    public string? LatestRevisionFqdn { get; set; }

    [JsonPropertyName("latestRevisionName")]
    public string? LatestRevisionName { get; set; }

    [JsonPropertyName("provisioningState")]
    public ContainerAppProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("template")]
    public TemplateModel? Template { get; set; }
}
