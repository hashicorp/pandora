using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_02.Disks;


internal class DiskUpdatePropertiesModel
{
    [JsonPropertyName("burstingEnabled")]
    public bool? BurstingEnabled { get; set; }

    [JsonPropertyName("dataAccessAuthMode")]
    public DataAccessAuthModeConstant? DataAccessAuthMode { get; set; }

    [JsonPropertyName("diskAccessId")]
    public string? DiskAccessId { get; set; }

    [JsonPropertyName("diskIOPSReadOnly")]
    public int? DiskIOPSReadOnly { get; set; }

    [JsonPropertyName("diskIOPSReadWrite")]
    public int? DiskIOPSReadWrite { get; set; }

    [JsonPropertyName("diskMBpsReadOnly")]
    public int? DiskMBpsReadOnly { get; set; }

    [JsonPropertyName("diskMBpsReadWrite")]
    public int? DiskMBpsReadWrite { get; set; }

    [JsonPropertyName("diskSizeGB")]
    public int? DiskSizeGB { get; set; }

    [JsonPropertyName("encryption")]
    public EncryptionModel? Encryption { get; set; }

    [JsonPropertyName("encryptionSettingsCollection")]
    public EncryptionSettingsCollectionModel? EncryptionSettingsCollection { get; set; }

    [JsonPropertyName("maxShares")]
    public int? MaxShares { get; set; }

    [JsonPropertyName("networkAccessPolicy")]
    public NetworkAccessPolicyConstant? NetworkAccessPolicy { get; set; }

    [JsonPropertyName("osType")]
    public OperatingSystemTypesConstant? OsType { get; set; }

    [JsonPropertyName("propertyUpdatesInProgress")]
    public PropertyUpdatesInProgressModel? PropertyUpdatesInProgress { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessConstant? PublicNetworkAccess { get; set; }

    [JsonPropertyName("purchasePlan")]
    public PurchasePlanModel? PurchasePlan { get; set; }

    [JsonPropertyName("supportedCapabilities")]
    public SupportedCapabilitiesModel? SupportedCapabilities { get; set; }

    [JsonPropertyName("supportsHibernation")]
    public bool? SupportsHibernation { get; set; }

    [JsonPropertyName("tier")]
    public string? Tier { get; set; }
}
