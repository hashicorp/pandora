using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2022_10_01.Pool;


internal class VirtualMachineConfigurationModel
{
    [JsonPropertyName("containerConfiguration")]
    public ContainerConfigurationModel? ContainerConfiguration { get; set; }

    [JsonPropertyName("dataDisks")]
    public List<DataDiskModel>? DataDisks { get; set; }

    [JsonPropertyName("diskEncryptionConfiguration")]
    public DiskEncryptionConfigurationModel? DiskEncryptionConfiguration { get; set; }

    [JsonPropertyName("extensions")]
    public List<VmExtensionModel>? Extensions { get; set; }

    [JsonPropertyName("imageReference")]
    [Required]
    public ImageReferenceModel ImageReference { get; set; }

    [JsonPropertyName("licenseType")]
    public string? LicenseType { get; set; }

    [JsonPropertyName("nodeAgentSkuId")]
    [Required]
    public string NodeAgentSkuId { get; set; }

    [JsonPropertyName("nodePlacementConfiguration")]
    public NodePlacementConfigurationModel? NodePlacementConfiguration { get; set; }

    [JsonPropertyName("osDisk")]
    public OSDiskModel? OsDisk { get; set; }

    [JsonPropertyName("windowsConfiguration")]
    public WindowsConfigurationModel? WindowsConfiguration { get; set; }
}
