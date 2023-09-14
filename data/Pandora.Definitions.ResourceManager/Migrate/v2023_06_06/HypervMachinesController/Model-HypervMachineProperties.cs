using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.HypervMachinesController;


internal class HypervMachinePropertiesModel
{
    [JsonPropertyName("allocatedMemoryInMb")]
    public float? AllocatedMemoryInMb { get; set; }

    [JsonPropertyName("applianceNames")]
    public List<string>? ApplianceNames { get; set; }

    [JsonPropertyName("applicationDiscovery")]
    public ApplicationDiscoveryModel? ApplicationDiscovery { get; set; }

    [JsonPropertyName("appsAndRoles")]
    public AppsAndRolesModel? AppsAndRoles { get; set; }

    [JsonPropertyName("biosGuid")]
    public string? BiosGuid { get; set; }

    [JsonPropertyName("biosSerialNumber")]
    public string? BiosSerialNumber { get; set; }

    [JsonPropertyName("clusterFqdn")]
    public string? ClusterFqdn { get; set; }

    [JsonPropertyName("clusterId")]
    public string? ClusterId { get; set; }

    [JsonPropertyName("createdTimestamp")]
    public string? CreatedTimestamp { get; set; }

    [JsonPropertyName("dataProtectionRequested")]
    public bool? DataProtectionRequested { get; set; }

    [JsonPropertyName("dependencyMapDiscovery")]
    public DependencyMapDiscoveryModel? DependencyMapDiscovery { get; set; }

    [JsonPropertyName("dependencyMapping")]
    public string? DependencyMapping { get; set; }

    [JsonPropertyName("dependencyMappingEndTime")]
    public string? DependencyMappingEndTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("dependencyMappingStartTime")]
    public DateTime? DependencyMappingStartTime { get; set; }

    [JsonPropertyName("disks")]
    public List<HypervDiskModel>? Disks { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("encryptStateAndVmMigrationTraffic")]
    public bool? EncryptStateAndVMMigrationTraffic { get; set; }

    [JsonPropertyName("errors")]
    public List<HealthErrorDetailsModel>? Errors { get; set; }

    [JsonPropertyName("firmware")]
    public string? Firmware { get; set; }

    [JsonPropertyName("generation")]
    public int? Generation { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("guestDetailsDiscoveryTimestamp")]
    public DateTime? GuestDetailsDiscoveryTimestamp { get; set; }

    [JsonPropertyName("guestOsDetails")]
    public GuestOsDetailsModel? GuestOsDetails { get; set; }

    [JsonPropertyName("highAvailability")]
    public HighAvailabilityConstant? HighAvailability { get; set; }

    [JsonPropertyName("hostFqdn")]
    public string? HostFqdn { get; set; }

    [JsonPropertyName("hostId")]
    public string? HostId { get; set; }

    [JsonPropertyName("iisDiscovery")]
    public WebAppDiscoveryModel? IisDiscovery { get; set; }

    [JsonPropertyName("instanceUuid")]
    public string? InstanceUuid { get; set; }

    [JsonPropertyName("isDeleted")]
    public bool? IsDeleted { get; set; }

    [JsonPropertyName("isDynamicMemoryEnabled")]
    public bool? IsDynamicMemoryEnabled { get; set; }

    [JsonPropertyName("isGuestDetailsDiscoveryInProgress")]
    public bool? IsGuestDetailsDiscoveryInProgress { get; set; }

    [JsonPropertyName("ksdEnabled")]
    public bool? KsdEnabled { get; set; }

    [JsonPropertyName("managementServerType")]
    public string? ManagementServerType { get; set; }

    [JsonPropertyName("maxMemoryMb")]
    public int? MaxMemoryMb { get; set; }

    [JsonPropertyName("networkAdapters")]
    public List<HypervNetworkAdapterModel>? NetworkAdapters { get; set; }

    [JsonPropertyName("numberOfApplications")]
    public int? NumberOfApplications { get; set; }

    [JsonPropertyName("numberOfProcessorCore")]
    public int? NumberOfProcessorCore { get; set; }

    [JsonPropertyName("operatingSystemDetails")]
    public OperatingSystemModel? OperatingSystemDetails { get; set; }

    [JsonPropertyName("oracleDiscovery")]
    public OracleDiscoveryModel? OracleDiscovery { get; set; }

    [JsonPropertyName("powerStatus")]
    public string? PowerStatus { get; set; }

    [JsonPropertyName("productSupportStatus")]
    public ProductSupportStatusModel? ProductSupportStatus { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("runAsAccountId")]
    public string? RunAsAccountId { get; set; }

    [JsonPropertyName("secureBootEnabled")]
    public bool? SecureBootEnabled { get; set; }

    [JsonPropertyName("secureBootTemplate")]
    public string? SecureBootTemplate { get; set; }

    [JsonPropertyName("secureBootTemplateId")]
    public string? SecureBootTemplateId { get; set; }

    [JsonPropertyName("shieldingRequested")]
    public bool? ShieldingRequested { get; set; }

    [JsonPropertyName("springBootDiscovery")]
    public SpringBootDiscoveryModel? SpringBootDiscovery { get; set; }

    [JsonPropertyName("sqlDiscovery")]
    public SqlDiscoveryModel? SqlDiscovery { get; set; }

    [JsonPropertyName("staticDiscovery")]
    public StaticDiscoveryModel? StaticDiscovery { get; set; }

    [JsonPropertyName("tags")]
    public CustomTypes.Tags? Tags { get; set; }

    [JsonPropertyName("tomcatDiscovery")]
    public WebAppDiscoveryModel? TomcatDiscovery { get; set; }

    [JsonPropertyName("tpmEnabled")]
    public bool? TpmEnabled { get; set; }

    [JsonPropertyName("updatedTimestamp")]
    public string? UpdatedTimestamp { get; set; }

    [JsonPropertyName("vmConfigurationFileLocation")]
    public string? VMConfigurationFileLocation { get; set; }

    [JsonPropertyName("vmFqdn")]
    public string? VMFqdn { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }

    [JsonPropertyName("virtualizationBasedSecurityOptOut")]
    public bool? VirtualizationBasedSecurityOptOut { get; set; }

    [JsonPropertyName("webAppDiscovery")]
    public WebAppDiscoveryModel? WebAppDiscovery { get; set; }
}
