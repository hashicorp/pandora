using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2021_06_01.Clusters;


internal class ClusterPropertiesModel
{
    [JsonPropertyName("associatedWorkspaces")]
    public List<AssociatedWorkspaceModel>? AssociatedWorkspaces { get; set; }

    [JsonPropertyName("billingType")]
    public BillingTypeConstant? BillingType { get; set; }

    [JsonPropertyName("capacityReservationProperties")]
    public CapacityReservationPropertiesModel? CapacityReservationProperties { get; set; }

    [JsonPropertyName("clusterId")]
    public string? ClusterId { get; set; }

    [JsonPropertyName("createdDate")]
    public string? CreatedDate { get; set; }

    [JsonPropertyName("isAvailabilityZonesEnabled")]
    public bool? IsAvailabilityZonesEnabled { get; set; }

    [JsonPropertyName("isDoubleEncryptionEnabled")]
    public bool? IsDoubleEncryptionEnabled { get; set; }

    [JsonPropertyName("keyVaultProperties")]
    public KeyVaultPropertiesModel? KeyVaultProperties { get; set; }

    [JsonPropertyName("lastModifiedDate")]
    public string? LastModifiedDate { get; set; }

    [JsonPropertyName("provisioningState")]
    public ClusterEntityStatusConstant? ProvisioningState { get; set; }
}
