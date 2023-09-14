using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.SqlAvailabilityGroupsController;


internal class SqlAvailabilityGroupPropertiesModel
{
    [JsonPropertyName("availabilityGroupName")]
    public string? AvailabilityGroupName { get; set; }

    [JsonPropertyName("availabilityGroupType")]
    public SqlAvailabilityGroupPropertiesAvailabilityGroupTypeConstant? AvailabilityGroupType { get; set; }

    [JsonPropertyName("availabilityReplicas")]
    public List<SqlAvailabilityReplicaPropertiesModel>? AvailabilityReplicas { get; set; }

    [JsonPropertyName("clusterName")]
    public string? ClusterName { get; set; }

    [JsonPropertyName("createdTimestamp")]
    public string? CreatedTimestamp { get; set; }

    [JsonPropertyName("isDeleted")]
    public bool? IsDeleted { get; set; }

    [JsonPropertyName("isMultiSubNet")]
    public bool? IsMultiSubNet { get; set; }

    [JsonPropertyName("isPartOfDistributedAvailabilityGroup")]
    public bool? IsPartOfDistributedAvailabilityGroup { get; set; }

    [JsonPropertyName("parentReplicaOverviewList")]
    public List<SqlAvailabilityReplicaOverviewModel>? ParentReplicaOverviewList { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("updatedTimestamp")]
    public string? UpdatedTimestamp { get; set; }
}
