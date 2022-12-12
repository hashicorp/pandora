using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2022_11_01.PacketCoreControlPlanes;


internal class PacketCoreControlPlanePropertiesFormatModel
{
    [JsonPropertyName("controlPlaneAccessInterface")]
    [Required]
    public InterfacePropertiesModel ControlPlaneAccessInterface { get; set; }

    [JsonPropertyName("coreNetworkTechnology")]
    public CoreNetworkTypeConstant? CoreNetworkTechnology { get; set; }

    [JsonPropertyName("installation")]
    public InstallationModel? Installation { get; set; }

    [JsonPropertyName("interopSettings")]
    public object? InteropSettings { get; set; }

    [JsonPropertyName("localDiagnosticsAccess")]
    [Required]
    public LocalDiagnosticsAccessConfigurationModel LocalDiagnosticsAccess { get; set; }

    [JsonPropertyName("platform")]
    [Required]
    public PlatformConfigurationModel Platform { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("rollbackVersion")]
    public string? RollbackVersion { get; set; }

    [MinItems(1)]
    [JsonPropertyName("sites")]
    [Required]
    public List<SiteResourceIdModel> Sites { get; set; }

    [JsonPropertyName("sku")]
    [Required]
    public BillingSkuConstant Sku { get; set; }

    [JsonPropertyName("ueMtu")]
    public int? UeMtu { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
