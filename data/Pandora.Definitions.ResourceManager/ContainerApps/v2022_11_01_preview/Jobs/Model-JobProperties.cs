using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_11_01_preview.Jobs;


internal class JobPropertiesModel
{
    [JsonPropertyName("configuration")]
    public JobConfigurationModel? Configuration { get; set; }

    [JsonPropertyName("environmentId")]
    public string? EnvironmentId { get; set; }

    [JsonPropertyName("eventStreamEndpoint")]
    public string? EventStreamEndpoint { get; set; }

    [JsonPropertyName("outboundIpAddresses")]
    public List<string>? OutboundIPAddresses { get; set; }

    [JsonPropertyName("provisioningState")]
    public JobProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("template")]
    public JobTemplateModel? Template { get; set; }

    [JsonPropertyName("workloadProfileName")]
    public string? WorkloadProfileName { get; set; }
}
