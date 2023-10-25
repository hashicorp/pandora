using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.DistributedAvailabilityGroups;


internal class CreateOrUpdatePropertiesModel
{
    [JsonPropertyName("primaryAvailabilityGroupName")]
    public string? PrimaryAvailabilityGroupName { get; set; }

    [JsonPropertyName("replicationMode")]
    public ReplicationModeTypeConstant? ReplicationMode { get; set; }

    [JsonPropertyName("secondaryAvailabilityGroupName")]
    public string? SecondaryAvailabilityGroupName { get; set; }

    [JsonPropertyName("sourceEndpoint")]
    public string? SourceEndpoint { get; set; }

    [JsonPropertyName("targetDatabase")]
    public string? TargetDatabase { get; set; }
}
