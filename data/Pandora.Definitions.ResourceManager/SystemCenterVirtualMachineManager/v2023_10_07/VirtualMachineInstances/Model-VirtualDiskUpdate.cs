using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SystemCenterVirtualMachineManager.v2023_10_07.VirtualMachineInstances;


internal class VirtualDiskUpdateModel
{
    [JsonPropertyName("bus")]
    public int? Bus { get; set; }

    [JsonPropertyName("busType")]
    public string? BusType { get; set; }

    [JsonPropertyName("diskId")]
    public string? DiskId { get; set; }

    [JsonPropertyName("diskSizeGB")]
    public int? DiskSizeGB { get; set; }

    [JsonPropertyName("lun")]
    public int? Lun { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("storageQoSPolicy")]
    public StorageQoSPolicyDetailsModel? StorageQoSPolicy { get; set; }

    [JsonPropertyName("vhdType")]
    public string? VhdType { get; set; }
}
