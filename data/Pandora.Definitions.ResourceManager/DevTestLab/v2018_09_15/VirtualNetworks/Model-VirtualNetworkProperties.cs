using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.VirtualNetworks;


internal class VirtualNetworkPropertiesModel
{
    [JsonPropertyName("allowedSubnets")]
    public List<SubnetModel>? AllowedSubnets { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdDate")]
    public DateTime? CreatedDate { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("externalProviderResourceId")]
    public string? ExternalProviderResourceId { get; set; }

    [JsonPropertyName("externalSubnets")]
    public List<ExternalSubnetModel>? ExternalSubnets { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("subnetOverrides")]
    public List<SubnetOverrideModel>? SubnetOverrides { get; set; }

    [JsonPropertyName("uniqueIdentifier")]
    public string? UniqueIdentifier { get; set; }
}
