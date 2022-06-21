using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.VirtualMachineSizes;


internal class EstimatedVMPriceModel
{
    [JsonPropertyName("osType")]
    [Required]
    public VMPriceOSTypeConstant OsType { get; set; }

    [JsonPropertyName("retailPrice")]
    [Required]
    public float RetailPrice { get; set; }

    [JsonPropertyName("vmTier")]
    [Required]
    public VMTierConstant VmTier { get; set; }
}
