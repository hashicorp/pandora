using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_08_15.ManagedCassandras;


internal class ClusterResourcePropertiesModel
{
    [JsonPropertyName("authenticationMethod")]
    public AuthenticationMethodConstant? AuthenticationMethod { get; set; }

    [JsonPropertyName("cassandraAuditLoggingEnabled")]
    public bool? CassandraAuditLoggingEnabled { get; set; }

    [JsonPropertyName("cassandraVersion")]
    public string? CassandraVersion { get; set; }

    [JsonPropertyName("clientCertificates")]
    public List<CertificateModel>? ClientCertificates { get; set; }

    [JsonPropertyName("clusterNameOverride")]
    public string? ClusterNameOverride { get; set; }

    [JsonPropertyName("deallocated")]
    public bool? Deallocated { get; set; }

    [JsonPropertyName("delegatedManagementSubnetId")]
    public string? DelegatedManagementSubnetId { get; set; }

    [JsonPropertyName("externalGossipCertificates")]
    public List<CertificateModel>? ExternalGossipCertificates { get; set; }

    [JsonPropertyName("externalSeedNodes")]
    public List<SeedNodeModel>? ExternalSeedNodes { get; set; }

    [JsonPropertyName("gossipCertificates")]
    public List<CertificateModel>? GossipCertificates { get; set; }

    [JsonPropertyName("hoursBetweenBackups")]
    public int? HoursBetweenBackups { get; set; }

    [JsonPropertyName("initialCassandraAdminPassword")]
    public string? InitialCassandraAdminPassword { get; set; }

    [JsonPropertyName("prometheusEndpoint")]
    public SeedNodeModel? PrometheusEndpoint { get; set; }

    [JsonPropertyName("provisioningState")]
    public ManagedCassandraProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("repairEnabled")]
    public bool? RepairEnabled { get; set; }

    [JsonPropertyName("restoreFromBackupId")]
    public string? RestoreFromBackupId { get; set; }

    [JsonPropertyName("seedNodes")]
    public List<SeedNodeModel>? SeedNodes { get; set; }
}
