using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_01.Images;


internal class ImagePropertiesModel
{
    [JsonPropertyName("hyperVGeneration")]
    public HyperVGenerationTypesConstant? HyperVGeneration { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("sourceVirtualMachine")]
    public SubResourceModel? SourceVirtualMachine { get; set; }

    [JsonPropertyName("storageProfile")]
    public ImageStorageProfileModel? StorageProfile { get; set; }
}
