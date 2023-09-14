using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.MachinesController;


internal class VMwareMachinePropertiesModel
{
    [JsonPropertyName("allocatedMemoryInMb")]
    public float? AllocatedMemoryInMb { get; set; }

    [JsonPropertyName("altGuestName")]
    public string? AltGuestName { get; set; }

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

    [JsonPropertyName("changeTrackingEnabled")]
    public bool? ChangeTrackingEnabled { get; set; }

    [JsonPropertyName("changeTrackingSupported")]
    public bool? ChangeTrackingSupported { get; set; }

    [JsonPropertyName("createdTimestamp")]
    public string? CreatedTimestamp { get; set; }

    [JsonPropertyName("dataCenterScope")]
    public string? DataCenterScope { get; set; }

    [JsonPropertyName("dependencyMapDiscovery")]
    public DependencyMapDiscoveryModel? DependencyMapDiscovery { get; set; }

    [JsonPropertyName("dependencyMapping")]
    public string? DependencyMapping { get; set; }

    [JsonPropertyName("dependencyMappingEndTime")]
    public string? DependencyMappingEndTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("dependencyMappingStartTime")]
    public DateTime? DependencyMappingStartTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("diskEnabledUuid")]
    public string? DiskEnabledUuid { get; set; }

    [JsonPropertyName("disks")]
    public List<VMwareDiskModel>? Disks { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("errors")]
    public List<HealthErrorDetailsModel>? Errors { get; set; }

    [JsonPropertyName("firmware")]
    public string? Firmware { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("guestDetailsDiscoveryTimestamp")]
    public DateTime? GuestDetailsDiscoveryTimestamp { get; set; }

    [JsonPropertyName("guestOsDetails")]
    public GuestOsDetailsModel? GuestOsDetails { get; set; }

    [JsonPropertyName("hostInMaintenanceMode")]
    public bool? HostInMaintenanceMode { get; set; }

    [JsonPropertyName("hostName")]
    public string? HostName { get; set; }

    [JsonPropertyName("hostPowerState")]
    public string? HostPowerState { get; set; }

    [JsonPropertyName("hostVersion")]
    public string? HostVersion { get; set; }

    [JsonPropertyName("iisDiscovery")]
    public WebAppDiscoveryModel? IisDiscovery { get; set; }

    [JsonPropertyName("instanceUuid")]
    public string? InstanceUuid { get; set; }

    [JsonPropertyName("isDeleted")]
    public bool? IsDeleted { get; set; }

    [JsonPropertyName("isGuestDetailsDiscoveryInProgress")]
    public bool? IsGuestDetailsDiscoveryInProgress { get; set; }

    [JsonPropertyName("maxSnapshots")]
    public int? MaxSnapshots { get; set; }

    [JsonPropertyName("networkAdapters")]
    public List<VMwareNetworkAdapterModel>? NetworkAdapters { get; set; }

    [JsonPropertyName("numberOfApplications")]
    public int? NumberOfApplications { get; set; }

    [JsonPropertyName("numberOfProcessorCore")]
    public int? NumberOfProcessorCore { get; set; }

    [JsonPropertyName("numberOfSnapshots")]
    public int? NumberOfSnapshots { get; set; }

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

    [JsonPropertyName("updatedTimestamp")]
    public string? UpdatedTimestamp { get; set; }

    [JsonPropertyName("vCenterFqdn")]
    public string? VCenterFqdn { get; set; }

    [JsonPropertyName("vCenterId")]
    public string? VCenterId { get; set; }

    [JsonPropertyName("vmConfigurationFileLocation")]
    public string? VMConfigurationFileLocation { get; set; }

    [JsonPropertyName("vmFqdn")]
    public string? VMFqdn { get; set; }

    [JsonPropertyName("vMwareToolsStatus")]
    public string? VMwareToolsStatus { get; set; }

    [JsonPropertyName("vMwareToolsVersion")]
    public string? VMwareToolsVersion { get; set; }

    [JsonPropertyName("webAppDiscovery")]
    public WebAppDiscoveryModel? WebAppDiscovery { get; set; }
}
