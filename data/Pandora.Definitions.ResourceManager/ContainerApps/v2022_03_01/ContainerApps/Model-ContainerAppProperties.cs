using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_03_01.ContainerApps;


internal class ContainerAppPropertiesModel
{
    [JsonPropertyName("configuration")]
    public ConfigurationModel? Configuration { get; set; }

    [JsonPropertyName("customDomainVerificationId")]
    public string? CustomDomainVerificationId { get; set; }

    [JsonPropertyName("latestRevisionFqdn")]
    public string? LatestRevisionFqdn { get; set; }

    [JsonPropertyName("latestRevisionName")]
    public string? LatestRevisionName { get; set; }

    [JsonPropertyName("managedEnvironmentId")]
    public string? ManagedEnvironmentId { get; set; }

    [JsonPropertyName("outboundIPAddresses")]
    public List<string>? OutboundIPAddresses { get; set; }

    [JsonPropertyName("provisioningState")]
    public ContainerAppProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("template")]
    public TemplateModel? Template { get; set; }
}
