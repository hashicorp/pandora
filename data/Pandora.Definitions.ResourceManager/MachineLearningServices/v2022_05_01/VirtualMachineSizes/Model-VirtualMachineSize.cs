using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.VirtualMachineSizes;


internal class VirtualMachineSizeModel
{
    [JsonPropertyName("estimatedVMPrices")]
    public EstimatedVMPricesModel? EstimatedVMPrices { get; set; }

    [JsonPropertyName("family")]
    public string? Family { get; set; }

    [JsonPropertyName("gpus")]
    public int? Gpus { get; set; }

    [JsonPropertyName("lowPriorityCapable")]
    public bool? LowPriorityCapable { get; set; }

    [JsonPropertyName("maxResourceVolumeMB")]
    public int? MaxResourceVolumeMB { get; set; }

    [JsonPropertyName("memoryGB")]
    public float? MemoryGB { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("osVhdSizeMB")]
    public int? OsVhdSizeMB { get; set; }

    [JsonPropertyName("premiumIO")]
    public bool? PremiumIO { get; set; }

    [JsonPropertyName("supportedComputeTypes")]
    public List<string>? SupportedComputeTypes { get; set; }

    [JsonPropertyName("vCPUs")]
    public int? VCPUs { get; set; }
}
