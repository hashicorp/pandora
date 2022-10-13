using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2022_09_01.Clusters;


internal class ClusterPatchPropertiesModel
{
    [JsonPropertyName("aadClientId")]
    public string? AadClientId { get; set; }

    [JsonPropertyName("aadTenantId")]
    public string? AadTenantId { get; set; }

    [JsonPropertyName("cloudManagementEndpoint")]
    public string? CloudManagementEndpoint { get; set; }

    [JsonPropertyName("desiredProperties")]
    public ClusterDesiredPropertiesModel? DesiredProperties { get; set; }
}
