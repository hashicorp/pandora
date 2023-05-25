using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.InstanceFailoverGroups;


internal class InstanceFailoverGroupPropertiesModel
{
    [JsonPropertyName("managedInstancePairs")]
    [Required]
    public List<ManagedInstancePairInfoModel> ManagedInstancePairs { get; set; }

    [JsonPropertyName("partnerRegions")]
    [Required]
    public List<PartnerRegionInfoModel> PartnerRegions { get; set; }

    [JsonPropertyName("readOnlyEndpoint")]
    public InstanceFailoverGroupReadOnlyEndpointModel? ReadOnlyEndpoint { get; set; }

    [JsonPropertyName("readWriteEndpoint")]
    [Required]
    public InstanceFailoverGroupReadWriteEndpointModel ReadWriteEndpoint { get; set; }

    [JsonPropertyName("replicationRole")]
    public InstanceFailoverGroupReplicationRoleConstant? ReplicationRole { get; set; }

    [JsonPropertyName("replicationState")]
    public string? ReplicationState { get; set; }

    [JsonPropertyName("secondaryType")]
    public SecondaryInstanceTypeConstant? SecondaryType { get; set; }
}
