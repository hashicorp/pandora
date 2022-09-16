using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.SqlPoolsReplicationLinks;


internal class ReplicationLinkPropertiesModel
{
    [JsonPropertyName("isTerminationAllowed")]
    public bool? IsTerminationAllowed { get; set; }

    [JsonPropertyName("partnerDatabase")]
    public string? PartnerDatabase { get; set; }

    [JsonPropertyName("partnerLocation")]
    public string? PartnerLocation { get; set; }

    [JsonPropertyName("partnerRole")]
    public ReplicationRoleConstant? PartnerRole { get; set; }

    [JsonPropertyName("partnerServer")]
    public string? PartnerServer { get; set; }

    [JsonPropertyName("percentComplete")]
    public int? PercentComplete { get; set; }

    [JsonPropertyName("replicationMode")]
    public string? ReplicationMode { get; set; }

    [JsonPropertyName("replicationState")]
    public ReplicationStateConstant? ReplicationState { get; set; }

    [JsonPropertyName("role")]
    public ReplicationRoleConstant? Role { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; set; }
}
