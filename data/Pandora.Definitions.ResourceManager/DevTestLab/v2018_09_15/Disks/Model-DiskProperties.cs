using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.Disks;


internal class DiskPropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdDate")]
    public DateTime? CreatedDate { get; set; }

    [JsonPropertyName("diskBlobName")]
    public string? DiskBlobName { get; set; }

    [JsonPropertyName("diskSizeGiB")]
    public int? DiskSizeGiB { get; set; }

    [JsonPropertyName("diskType")]
    public StorageTypeConstant? DiskType { get; set; }

    [JsonPropertyName("diskUri")]
    public string? DiskUri { get; set; }

    [JsonPropertyName("hostCaching")]
    public string? HostCaching { get; set; }

    [JsonPropertyName("leasedByLabVmId")]
    public string? LeasedByLabVMId { get; set; }

    [JsonPropertyName("managedDiskId")]
    public string? ManagedDiskId { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("storageAccountId")]
    public string? StorageAccountId { get; set; }

    [JsonPropertyName("uniqueIdentifier")]
    public string? UniqueIdentifier { get; set; }
}
