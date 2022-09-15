using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.VirtualMachineScaleSets;


internal class VirtualMachineScaleSetUpdateStorageProfileModel
{
    [JsonPropertyName("dataDisks")]
    public List<VirtualMachineScaleSetDataDiskModel>? DataDisks { get; set; }

    [JsonPropertyName("imageReference")]
    public ImageReferenceModel? ImageReference { get; set; }

    [JsonPropertyName("osDisk")]
    public VirtualMachineScaleSetUpdateOSDiskModel? OsDisk { get; set; }
}
