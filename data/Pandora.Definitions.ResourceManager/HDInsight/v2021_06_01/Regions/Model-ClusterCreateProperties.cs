using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HDInsight.v2021_06_01.Regions;


internal class ClusterCreatePropertiesModel
{
    [JsonPropertyName("clusterDefinition")]
    public ClusterDefinitionModel? ClusterDefinition { get; set; }

    [JsonPropertyName("clusterVersion")]
    public string? ClusterVersion { get; set; }

    [JsonPropertyName("computeIsolationProperties")]
    public ComputeIsolationPropertiesModel? ComputeIsolationProperties { get; set; }

    [JsonPropertyName("computeProfile")]
    public ComputeProfileModel? ComputeProfile { get; set; }

    [JsonPropertyName("diskEncryptionProperties")]
    public DiskEncryptionPropertiesModel? DiskEncryptionProperties { get; set; }

    [JsonPropertyName("encryptionInTransitProperties")]
    public EncryptionInTransitPropertiesModel? EncryptionInTransitProperties { get; set; }

    [JsonPropertyName("kafkaRestProperties")]
    public KafkaRestPropertiesModel? KafkaRestProperties { get; set; }

    [JsonPropertyName("minSupportedTlsVersion")]
    public string? MinSupportedTlsVersion { get; set; }

    [JsonPropertyName("networkProperties")]
    public NetworkPropertiesModel? NetworkProperties { get; set; }

    [JsonPropertyName("osType")]
    public OSTypeConstant? OsType { get; set; }

    [JsonPropertyName("privateLinkConfigurations")]
    public List<PrivateLinkConfigurationModel>? PrivateLinkConfigurations { get; set; }

    [JsonPropertyName("securityProfile")]
    public SecurityProfileModel? SecurityProfile { get; set; }

    [JsonPropertyName("storageProfile")]
    public StorageProfileModel? StorageProfile { get; set; }

    [JsonPropertyName("tier")]
    public TierConstant? Tier { get; set; }
}
