using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SAPVirtualInstances;


internal class SAPVirtualInstancePropertiesModel
{
    [JsonPropertyName("configuration")]
    [Required]
    public SAPConfigurationModel Configuration { get; set; }

    [JsonPropertyName("environment")]
    [Required]
    public SAPEnvironmentTypeConstant Environment { get; set; }

    [JsonPropertyName("errors")]
    public SAPVirtualInstanceErrorModel? Errors { get; set; }

    [JsonPropertyName("health")]
    public SAPHealthStateConstant? Health { get; set; }

    [JsonPropertyName("managedResourceGroupConfiguration")]
    public ManagedRGConfigurationModel? ManagedResourceGroupConfiguration { get; set; }

    [JsonPropertyName("provisioningState")]
    public SapVirtualInstanceProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("sapProduct")]
    [Required]
    public SAPProductTypeConstant SapProduct { get; set; }

    [JsonPropertyName("state")]
    public SAPVirtualInstanceStateConstant? State { get; set; }

    [JsonPropertyName("status")]
    public SAPVirtualInstanceStatusConstant? Status { get; set; }
}
