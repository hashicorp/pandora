using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AAD.v2022_09_01.OuContainer;


internal class OuContainerPropertiesModel
{
    [JsonPropertyName("accounts")]
    public List<ContainerAccountModel>? Accounts { get; set; }

    [JsonPropertyName("containerId")]
    public string? ContainerId { get; set; }

    [JsonPropertyName("deploymentId")]
    public string? DeploymentId { get; set; }

    [JsonPropertyName("distinguishedName")]
    public string? DistinguishedName { get; set; }

    [JsonPropertyName("domainName")]
    public string? DomainName { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("serviceStatus")]
    public string? ServiceStatus { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}
