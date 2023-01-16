using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.Labs;


internal class LabPropertiesModel
{
    [JsonPropertyName("announcement")]
    public LabAnnouncementPropertiesModel? Announcement { get; set; }

    [JsonPropertyName("artifactsStorageAccount")]
    public string? ArtifactsStorageAccount { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdDate")]
    public DateTime? CreatedDate { get; set; }

    [JsonPropertyName("defaultPremiumStorageAccount")]
    public string? DefaultPremiumStorageAccount { get; set; }

    [JsonPropertyName("defaultStorageAccount")]
    public string? DefaultStorageAccount { get; set; }

    [JsonPropertyName("environmentPermission")]
    public EnvironmentPermissionConstant? EnvironmentPermission { get; set; }

    [JsonPropertyName("extendedProperties")]
    public Dictionary<string, string>? ExtendedProperties { get; set; }

    [JsonPropertyName("labStorageType")]
    public StorageTypeConstant? LabStorageType { get; set; }

    [JsonPropertyName("loadBalancerId")]
    public string? LoadBalancerId { get; set; }

    [JsonPropertyName("mandatoryArtifactsResourceIdsLinux")]
    public List<string>? MandatoryArtifactsResourceIdsLinux { get; set; }

    [JsonPropertyName("mandatoryArtifactsResourceIdsWindows")]
    public List<string>? MandatoryArtifactsResourceIdsWindows { get; set; }

    [JsonPropertyName("networkSecurityGroupId")]
    public string? NetworkSecurityGroupId { get; set; }

    [JsonPropertyName("premiumDataDiskStorageAccount")]
    public string? PremiumDataDiskStorageAccount { get; set; }

    [JsonPropertyName("premiumDataDisks")]
    public PremiumDataDiskConstant? PremiumDataDisks { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("publicIpId")]
    public string? PublicIPId { get; set; }

    [JsonPropertyName("support")]
    public LabSupportPropertiesModel? Support { get; set; }

    [JsonPropertyName("uniqueIdentifier")]
    public string? UniqueIdentifier { get; set; }

    [JsonPropertyName("vmCreationResourceGroup")]
    public string? VMCreationResourceGroup { get; set; }

    [JsonPropertyName("vaultName")]
    public string? VaultName { get; set; }
}
