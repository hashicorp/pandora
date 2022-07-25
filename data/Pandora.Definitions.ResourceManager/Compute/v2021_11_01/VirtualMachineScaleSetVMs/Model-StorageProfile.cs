using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachineScaleSetVMs;


internal class StorageProfileModel
{
    [JsonPropertyName("dataDisks")]
    public List<DataDiskModel>? DataDisks { get; set; }

    [JsonPropertyName("imageReference")]
    public ImageReferenceModel? ImageReference { get; set; }

    [JsonPropertyName("osDisk")]
    public OSDiskModel? OsDisk { get; set; }
}
