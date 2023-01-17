using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.Labs;


internal class LabVirtualMachineCreationParameterPropertiesModel
{
    [JsonPropertyName("allowClaim")]
    public bool? AllowClaim { get; set; }

    [JsonPropertyName("artifacts")]
    public List<ArtifactInstallPropertiesModel>? Artifacts { get; set; }

    [JsonPropertyName("bulkCreationParameters")]
    public BulkCreationParametersModel? BulkCreationParameters { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdDate")]
    public DateTime? CreatedDate { get; set; }

    [JsonPropertyName("customImageId")]
    public string? CustomImageId { get; set; }

    [JsonPropertyName("dataDiskParameters")]
    public List<DataDiskPropertiesModel>? DataDiskParameters { get; set; }

    [JsonPropertyName("disallowPublicIpAddress")]
    public bool? DisallowPublicIPAddress { get; set; }

    [JsonPropertyName("environmentId")]
    public string? EnvironmentId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("expirationDate")]
    public DateTime? ExpirationDate { get; set; }

    [JsonPropertyName("galleryImageReference")]
    public GalleryImageReferenceModel? GalleryImageReference { get; set; }

    [JsonPropertyName("isAuthenticationWithSshKey")]
    public bool? IsAuthenticationWithSshKey { get; set; }

    [JsonPropertyName("labSubnetName")]
    public string? LabSubnetName { get; set; }

    [JsonPropertyName("labVirtualNetworkId")]
    public string? LabVirtualNetworkId { get; set; }

    [JsonPropertyName("networkInterface")]
    public NetworkInterfacePropertiesModel? NetworkInterface { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("ownerObjectId")]
    public string? OwnerObjectId { get; set; }

    [JsonPropertyName("ownerUserPrincipalName")]
    public string? OwnerUserPrincipalName { get; set; }

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("planId")]
    public string? PlanId { get; set; }

    [JsonPropertyName("scheduleParameters")]
    public List<ScheduleCreationParameterModel>? ScheduleParameters { get; set; }

    [JsonPropertyName("size")]
    public string? Size { get; set; }

    [JsonPropertyName("sshKey")]
    public string? SshKey { get; set; }

    [JsonPropertyName("storageType")]
    public string? StorageType { get; set; }

    [JsonPropertyName("userName")]
    public string? UserName { get; set; }
}
