using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VMware.v2022_05_01.WorkloadNetworks;


internal class WorkloadNetworkPublicIPPropertiesModel
{
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("numberOfPublicIPs")]
    public int? NumberOfPublicIPs { get; set; }

    [JsonPropertyName("provisioningState")]
    public WorkloadNetworkPublicIPProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publicIPBlock")]
    public string? PublicIPBlock { get; set; }
}
