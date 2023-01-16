using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.VirtualMachines;


internal class ComputeVMPropertiesModel
{
    [JsonPropertyName("dataDiskIds")]
    public List<string>? DataDiskIds { get; set; }

    [JsonPropertyName("dataDisks")]
    public List<ComputeDataDiskModel>? DataDisks { get; set; }

    [JsonPropertyName("networkInterfaceId")]
    public string? NetworkInterfaceId { get; set; }

    [JsonPropertyName("osDiskId")]
    public string? OsDiskId { get; set; }

    [JsonPropertyName("osType")]
    public string? OsType { get; set; }

    [JsonPropertyName("statuses")]
    public List<ComputeVMInstanceViewStatusModel>? Statuses { get; set; }

    [JsonPropertyName("vmSize")]
    public string? VMSize { get; set; }
}
