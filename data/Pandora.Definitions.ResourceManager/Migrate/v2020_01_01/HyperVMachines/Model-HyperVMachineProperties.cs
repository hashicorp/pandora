using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2020_01_01.HyperVMachines;


internal class HyperVMachinePropertiesModel
{
    [JsonPropertyName("allocatedMemoryInMB")]
    public float? AllocatedMemoryInMB { get; set; }

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

    [JsonPropertyName("disks")]
    public List<HyperVDiskModel>? Disks { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("errors")]
    public List<HealthErrorDetailsModel>? Errors { get; set; }

    [JsonPropertyName("firmware")]
    public string? Firmware { get; set; }

    [JsonPropertyName("generation")]
    public int? Generation { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("guestDetailsDiscoveryTimestamp")]
    public DateTime? GuestDetailsDiscoveryTimestamp { get; set; }

    [JsonPropertyName("guestOSDetails")]
    public GuestOSDetailsModel? GuestOSDetails { get; set; }

    [JsonPropertyName("highAvailability")]
    public HighlyAvailableConstant? HighAvailability { get; set; }

    [JsonPropertyName("hostFqdn")]
    public string? HostFqdn { get; set; }

    [JsonPropertyName("hostId")]
    public string? HostId { get; set; }

    [JsonPropertyName("instanceUuid")]
    public string? InstanceUuid { get; set; }

    [JsonPropertyName("isDeleted")]
    public bool? IsDeleted { get; set; }

    [JsonPropertyName("isDynamicMemoryEnabled")]
    public bool? IsDynamicMemoryEnabled { get; set; }

    [JsonPropertyName("isGuestDetailsDiscoveryInProgress")]
    public bool? IsGuestDetailsDiscoveryInProgress { get; set; }

    [JsonPropertyName("managementServerType")]
    public string? ManagementServerType { get; set; }

    [JsonPropertyName("maxMemoryMB")]
    public int? MaxMemoryMB { get; set; }

    [JsonPropertyName("networkAdapters")]
    public List<HyperVNetworkAdapterModel>? NetworkAdapters { get; set; }

    [JsonPropertyName("numberOfApplications")]
    public int? NumberOfApplications { get; set; }

    [JsonPropertyName("numberOfProcessorCore")]
    public int? NumberOfProcessorCore { get; set; }

    [JsonPropertyName("operatingSystemDetails")]
    public OperatingSystemModel? OperatingSystemDetails { get; set; }

    [JsonPropertyName("powerStatus")]
    public string? PowerStatus { get; set; }

    [JsonPropertyName("updatedTimestamp")]
    public string? UpdatedTimestamp { get; set; }

    [JsonPropertyName("vmConfigurationFileLocation")]
    public string? VMConfigurationFileLocation { get; set; }

    [JsonPropertyName("vmFqdn")]
    public string? VMFqdn { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
