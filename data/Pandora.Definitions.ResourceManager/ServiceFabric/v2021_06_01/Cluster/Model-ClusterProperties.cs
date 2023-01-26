using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_06_01.Cluster;


internal class ClusterPropertiesModel
{
    [JsonPropertyName("addOnFeatures")]
    public List<AddOnFeaturesConstant>? AddOnFeatures { get; set; }

    [JsonPropertyName("applicationTypeVersionsCleanupPolicy")]
    public ApplicationTypeVersionsCleanupPolicyModel? ApplicationTypeVersionsCleanupPolicy { get; set; }

    [JsonPropertyName("availableClusterVersions")]
    public List<ClusterVersionDetailsModel>? AvailableClusterVersions { get; set; }

    [JsonPropertyName("azureActiveDirectory")]
    public AzureActiveDirectoryModel? AzureActiveDirectory { get; set; }

    [JsonPropertyName("certificate")]
    public CertificateDescriptionModel? Certificate { get; set; }

    [JsonPropertyName("certificateCommonNames")]
    public ServerCertificateCommonNamesModel? CertificateCommonNames { get; set; }

    [JsonPropertyName("clientCertificateCommonNames")]
    public List<ClientCertificateCommonNameModel>? ClientCertificateCommonNames { get; set; }

    [JsonPropertyName("clientCertificateThumbprints")]
    public List<ClientCertificateThumbprintModel>? ClientCertificateThumbprints { get; set; }

    [JsonPropertyName("clusterCodeVersion")]
    public string? ClusterCodeVersion { get; set; }

    [JsonPropertyName("clusterEndpoint")]
    public string? ClusterEndpoint { get; set; }

    [JsonPropertyName("clusterId")]
    public string? ClusterId { get; set; }

    [JsonPropertyName("clusterState")]
    public ClusterStateConstant? ClusterState { get; set; }

    [JsonPropertyName("diagnosticsStorageAccountConfig")]
    public DiagnosticsStorageAccountConfigModel? DiagnosticsStorageAccountConfig { get; set; }

    [JsonPropertyName("eventStoreServiceEnabled")]
    public bool? EventStoreServiceEnabled { get; set; }

    [JsonPropertyName("fabricSettings")]
    public List<SettingsSectionDescriptionModel>? FabricSettings { get; set; }

    [JsonPropertyName("infrastructureServiceManager")]
    public bool? InfrastructureServiceManager { get; set; }

    [JsonPropertyName("managementEndpoint")]
    [Required]
    public string ManagementEndpoint { get; set; }

    [JsonPropertyName("nodeTypes")]
    [Required]
    public List<NodeTypeDescriptionModel> NodeTypes { get; set; }

    [JsonPropertyName("notifications")]
    public List<NotificationModel>? Notifications { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("reliabilityLevel")]
    public ReliabilityLevelConstant? ReliabilityLevel { get; set; }

    [JsonPropertyName("reverseProxyCertificate")]
    public CertificateDescriptionModel? ReverseProxyCertificate { get; set; }

    [JsonPropertyName("reverseProxyCertificateCommonNames")]
    public ServerCertificateCommonNamesModel? ReverseProxyCertificateCommonNames { get; set; }

    [JsonPropertyName("sfZonalUpgradeMode")]
    public SfZonalUpgradeModeConstant? SfZonalUpgradeMode { get; set; }

    [JsonPropertyName("upgradeDescription")]
    public ClusterUpgradePolicyModel? UpgradeDescription { get; set; }

    [JsonPropertyName("upgradeMode")]
    public UpgradeModeConstant? UpgradeMode { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("upgradePauseEndTimestampUtc")]
    public DateTime? UpgradePauseEndTimestampUtc { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("upgradePauseStartTimestampUtc")]
    public DateTime? UpgradePauseStartTimestampUtc { get; set; }

    [JsonPropertyName("upgradeWave")]
    public ClusterUpgradeCadenceConstant? UpgradeWave { get; set; }

    [JsonPropertyName("vmssZonalUpgradeMode")]
    public VMSSZonalUpgradeModeConstant? VMSSZonalUpgradeMode { get; set; }

    [JsonPropertyName("vmImage")]
    public string? VmImage { get; set; }

    [JsonPropertyName("waveUpgradePaused")]
    public bool? WaveUpgradePaused { get; set; }
}
