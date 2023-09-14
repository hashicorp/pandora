using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.ImportMachinesController;


internal class ImportMachinePropertiesModel
{
    [JsonPropertyName("allocatedMemoryInMb")]
    public float? AllocatedMemoryInMb { get; set; }

    [JsonPropertyName("biosGuid")]
    public string? BiosGuid { get; set; }

    [JsonPropertyName("biosSerialNumber")]
    public string? BiosSerialNumber { get; set; }

    [JsonPropertyName("createdTimestamp")]
    public string? CreatedTimestamp { get; set; }

    [JsonPropertyName("disks")]
    public List<WebRoleImportDiskModel>? Disks { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("firmware")]
    public string? Firmware { get; set; }

    [JsonPropertyName("hypervisor")]
    public string? Hypervisor { get; set; }

    [JsonPropertyName("hypervisorVersionNumber")]
    public string? HypervisorVersionNumber { get; set; }

    [JsonPropertyName("ipAddresses")]
    public List<string>? IPAddresses { get; set; }

    [JsonPropertyName("isDeleted")]
    public bool? IsDeleted { get; set; }

    [JsonPropertyName("macAddress")]
    public string? MacAddress { get; set; }

    [JsonPropertyName("machineId")]
    public string? MachineId { get; set; }

    [JsonPropertyName("machineManagerId")]
    public string? MachineManagerId { get; set; }

    [JsonPropertyName("networkInThroughput")]
    public float? NetworkInThroughput { get; set; }

    [JsonPropertyName("networkOutThroughput")]
    public float? NetworkOutThroughput { get; set; }

    [JsonPropertyName("numberOfDisks")]
    public int? NumberOfDisks { get; set; }

    [JsonPropertyName("numberOfNetworkAdapters")]
    public int? NumberOfNetworkAdapters { get; set; }

    [JsonPropertyName("numberOfProcessorCore")]
    public int? NumberOfProcessorCore { get; set; }

    [JsonPropertyName("operatingSystemDetails")]
    public WebRoleOperatingSystemModel? OperatingSystemDetails { get; set; }

    [JsonPropertyName("percentageCpuUtilization")]
    public float? PercentageCPUUtilization { get; set; }

    [JsonPropertyName("percentageMemoryUtilization")]
    public float? PercentageMemoryUtilization { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("serverType")]
    public string? ServerType { get; set; }

    [JsonPropertyName("storageInUseGb")]
    public float? StorageInUseGb { get; set; }

    [JsonPropertyName("tags")]
    [Required]
    public CustomTypes.Tags Tags { get; set; }

    [JsonPropertyName("totalDiskReadOperationsPerSecond")]
    public float? TotalDiskReadOperationsPerSecond { get; set; }

    [JsonPropertyName("totalDiskReadThroughput")]
    public float? TotalDiskReadThroughput { get; set; }

    [JsonPropertyName("totalDiskWriteOperationsPerSecond")]
    public float? TotalDiskWriteOperationsPerSecond { get; set; }

    [JsonPropertyName("totalDiskWriteThroughput")]
    public float? TotalDiskWriteThroughput { get; set; }

    [JsonPropertyName("updatedTimestamp")]
    public string? UpdatedTimestamp { get; set; }

    [JsonPropertyName("vmFqdn")]
    public string? VMFqdn { get; set; }
}
