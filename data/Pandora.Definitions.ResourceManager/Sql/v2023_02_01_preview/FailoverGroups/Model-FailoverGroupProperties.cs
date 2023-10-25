using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.FailoverGroups;


internal class FailoverGroupPropertiesModel
{
    [JsonPropertyName("databases")]
    public List<string>? Databases { get; set; }

    [JsonPropertyName("partnerServers")]
    [Required]
    public List<PartnerInfoModel> PartnerServers { get; set; }

    [JsonPropertyName("readOnlyEndpoint")]
    public FailoverGroupReadOnlyEndpointModel? ReadOnlyEndpoint { get; set; }

    [JsonPropertyName("readWriteEndpoint")]
    [Required]
    public FailoverGroupReadWriteEndpointModel ReadWriteEndpoint { get; set; }

    [JsonPropertyName("replicationRole")]
    public FailoverGroupReplicationRoleConstant? ReplicationRole { get; set; }

    [JsonPropertyName("replicationState")]
    public string? ReplicationState { get; set; }
}
