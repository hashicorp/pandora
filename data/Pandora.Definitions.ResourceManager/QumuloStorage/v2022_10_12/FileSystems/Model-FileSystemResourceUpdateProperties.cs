using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.QumuloStorage.v2022_10_12.FileSystems;


internal class FileSystemResourceUpdatePropertiesModel
{
    [JsonPropertyName("clusterLoginUrl")]
    public string? ClusterLoginUrl { get; set; }

    [JsonPropertyName("delegatedSubnetId")]
    public string? DelegatedSubnetId { get; set; }

    [JsonPropertyName("marketplaceDetails")]
    public MarketplaceDetailsModel? MarketplaceDetails { get; set; }

    [JsonPropertyName("privateIPs")]
    public List<string>? PrivateIPs { get; set; }

    [JsonPropertyName("userDetails")]
    public UserDetailsModel? UserDetails { get; set; }
}
