using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_02.IncrementalRestorePoints;


internal class DiskRestorePointPropertiesModel
{
    [JsonPropertyName("completionPercent")]
    public float? CompletionPercent { get; set; }

    [JsonPropertyName("diskAccessId")]
    public string? DiskAccessId { get; set; }

    [JsonPropertyName("encryption")]
    public EncryptionModel? Encryption { get; set; }

    [JsonPropertyName("familyId")]
    public string? FamilyId { get; set; }

    [JsonPropertyName("hyperVGeneration")]
    public HyperVGenerationConstant? HyperVGeneration { get; set; }

    [JsonPropertyName("networkAccessPolicy")]
    public NetworkAccessPolicyConstant? NetworkAccessPolicy { get; set; }

    [JsonPropertyName("osType")]
    public OperatingSystemTypesConstant? OsType { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessConstant? PublicNetworkAccess { get; set; }

    [JsonPropertyName("purchasePlan")]
    public PurchasePlanModel? PurchasePlan { get; set; }

    [JsonPropertyName("replicationState")]
    public string? ReplicationState { get; set; }

    [JsonPropertyName("securityProfile")]
    public DiskSecurityProfileModel? SecurityProfile { get; set; }

    [JsonPropertyName("sourceResourceId")]
    public string? SourceResourceId { get; set; }

    [JsonPropertyName("sourceResourceLocation")]
    public string? SourceResourceLocation { get; set; }

    [JsonPropertyName("sourceUniqueId")]
    public string? SourceUniqueId { get; set; }

    [JsonPropertyName("supportedCapabilities")]
    public SupportedCapabilitiesModel? SupportedCapabilities { get; set; }

    [JsonPropertyName("supportsHibernation")]
    public bool? SupportsHibernation { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("timeCreated")]
    public DateTime? TimeCreated { get; set; }
}
