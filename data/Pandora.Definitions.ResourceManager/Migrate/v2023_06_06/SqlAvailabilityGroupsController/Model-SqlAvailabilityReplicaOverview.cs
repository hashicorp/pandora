using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.SqlAvailabilityGroupsController;


internal class SqlAvailabilityReplicaOverviewModel
{
    [JsonPropertyName("availabilityGroupArmId")]
    public string? AvailabilityGroupArmId { get; set; }

    [JsonPropertyName("availabilityGroupName")]
    public string? AvailabilityGroupName { get; set; }

    [JsonPropertyName("availabilityReplicaId")]
    public string? AvailabilityReplicaId { get; set; }

    [JsonPropertyName("replicaState")]
    public SqlAvailabilityReplicaOverviewReplicaStateConstant? ReplicaState { get; set; }
}
