using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2020_07_07.Machines;


internal class VMwareMachinePropertiesModel
{
    [JsonPropertyName("allocatedMemoryInMB")]
    public float? AllocatedMemoryInMB { get; set; }

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

    [JsonPropertyName("dependencyMapping")]
    public string? DependencyMapping { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("dependencyMappingStartTime")]
    public DateTime? DependencyMappingStartTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

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

    [JsonPropertyName("guestOSDetails")]
    public GuestOSDetailsModel? GuestOSDetails { get; set; }

    [JsonPropertyName("hostInMaintenanceMode")]
    public bool? HostInMaintenanceMode { get; set; }

    [JsonPropertyName("hostName")]
    public string? HostName { get; set; }

    [JsonPropertyName("hostPowerState")]
    public string? HostPowerState { get; set; }

    [JsonPropertyName("hostVersion")]
    public string? HostVersion { get; set; }

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

    [JsonPropertyName("operatingSystemDetails")]
    public OperatingSystemModel? OperatingSystemDetails { get; set; }

    [JsonPropertyName("powerStatus")]
    public string? PowerStatus { get; set; }

    [JsonPropertyName("updatedTimestamp")]
    public string? UpdatedTimestamp { get; set; }

    [JsonPropertyName("vCenterFQDN")]
    public string? VCenterFQDN { get; set; }

    [JsonPropertyName("vCenterId")]
    public string? VCenterId { get; set; }

    [JsonPropertyName("vmConfigurationFileLocation")]
    public string? VMConfigurationFileLocation { get; set; }

    [JsonPropertyName("vmFqdn")]
    public string? VMFqdn { get; set; }

    [JsonPropertyName("vMwareToolsStatus")]
    public string? VMwareToolsStatus { get; set; }
}
