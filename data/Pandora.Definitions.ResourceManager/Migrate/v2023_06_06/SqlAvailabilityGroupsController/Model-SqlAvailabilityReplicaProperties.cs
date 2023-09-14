using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.SqlAvailabilityGroupsController;


internal class SqlAvailabilityReplicaPropertiesModel
{
    [JsonPropertyName("availabilityReplicaId")]
    public string? AvailabilityReplicaId { get; set; }

    [JsonPropertyName("availabilityReplicaName")]
    public string? AvailabilityReplicaName { get; set; }

    [JsonPropertyName("replicaCommitMode")]
    public SqlAvailabilityGroupSqlAvailabilityReplicaPropertiesReplicaCommitModeConstant? ReplicaCommitMode { get; set; }

    [JsonPropertyName("replicaReadMode")]
    public SqlAvailabilityGroupSqlAvailabilityReplicaPropertiesReplicaReadModeConstant? ReplicaReadMode { get; set; }

    [JsonPropertyName("replicaSeedMode")]
    public SqlAvailabilityGroupSqlAvailabilityReplicaPropertiesReplicaSeedModeConstant? ReplicaSeedMode { get; set; }

    [JsonPropertyName("replicaState")]
    public SqlAvailabilityGroupSqlAvailabilityReplicaPropertiesReplicaStateConstant? ReplicaState { get; set; }

    [JsonPropertyName("replicaSyncStatus")]
    public SqlAvailabilityGroupSqlAvailabilityReplicaPropertiesReplicaSyncStatusConstant? ReplicaSyncStatus { get; set; }

    [JsonPropertyName("replicaType")]
    public SqlAvailabilityGroupSqlAvailabilityReplicaPropertiesReplicaTypeConstant? ReplicaType { get; set; }

    [JsonPropertyName("sqlAvailabilityGroupReplicaInfo")]
    public SqlAvailabilityGroupReplicaInfoModel? SqlAvailabilityGroupReplicaInfo { get; set; }

    [JsonPropertyName("sqlDatabaseReplicaInfo")]
    public SqlDatabaseReplicaInfoModel? SqlDatabaseReplicaInfo { get; set; }
}
