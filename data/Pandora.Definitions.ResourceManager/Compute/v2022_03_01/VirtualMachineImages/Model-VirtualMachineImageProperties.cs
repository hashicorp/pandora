using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_01.VirtualMachineImages;


internal class VirtualMachineImagePropertiesModel
{
    [JsonPropertyName("architecture")]
    public ArchitectureTypesConstant? Architecture { get; set; }

    [JsonPropertyName("automaticOSUpgradeProperties")]
    public AutomaticOSUpgradePropertiesModel? AutomaticOSUpgradeProperties { get; set; }

    [JsonPropertyName("dataDiskImages")]
    public List<DataDiskImageModel>? DataDiskImages { get; set; }

    [JsonPropertyName("disallowed")]
    public DisallowedConfigurationModel? Disallowed { get; set; }

    [JsonPropertyName("features")]
    public List<VirtualMachineImageFeatureModel>? Features { get; set; }

    [JsonPropertyName("hyperVGeneration")]
    public HyperVGenerationTypesConstant? HyperVGeneration { get; set; }

    [JsonPropertyName("osDiskImage")]
    public OSDiskImageModel? OsDiskImage { get; set; }

    [JsonPropertyName("plan")]
    public PurchasePlanModel? Plan { get; set; }
}
