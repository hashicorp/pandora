using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.VirtualMachines;


internal class LabVirtualMachinePropertiesModel
{
    [JsonPropertyName("allowClaim")]
    public bool? AllowClaim { get; set; }

    [JsonPropertyName("applicableSchedule")]
    public ApplicableScheduleModel? ApplicableSchedule { get; set; }

    [JsonPropertyName("artifactDeploymentStatus")]
    public ArtifactDeploymentStatusPropertiesModel? ArtifactDeploymentStatus { get; set; }

    [JsonPropertyName("artifacts")]
    public List<ArtifactInstallPropertiesModel>? Artifacts { get; set; }

    [JsonPropertyName("computeId")]
    public string? ComputeId { get; set; }

    [JsonPropertyName("computeVm")]
    public ComputeVMPropertiesModel? ComputeVM { get; set; }

    [JsonPropertyName("createdByUser")]
    public string? CreatedByUser { get; set; }

    [JsonPropertyName("createdByUserId")]
    public string? CreatedByUserId { get; set; }

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

    [JsonPropertyName("fqdn")]
    public string? Fqdn { get; set; }

    [JsonPropertyName("galleryImageReference")]
    public GalleryImageReferenceModel? GalleryImageReference { get; set; }

    [JsonPropertyName("isAuthenticationWithSshKey")]
    public bool? IsAuthenticationWithSshKey { get; set; }

    [JsonPropertyName("labSubnetName")]
    public string? LabSubnetName { get; set; }

    [JsonPropertyName("labVirtualNetworkId")]
    public string? LabVirtualNetworkId { get; set; }

    [JsonPropertyName("lastKnownPowerState")]
    public string? LastKnownPowerState { get; set; }

    [JsonPropertyName("networkInterface")]
    public NetworkInterfacePropertiesModel? NetworkInterface { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("osType")]
    public string? OsType { get; set; }

    [JsonPropertyName("ownerObjectId")]
    public string? OwnerObjectId { get; set; }

    [JsonPropertyName("ownerUserPrincipalName")]
    public string? OwnerUserPrincipalName { get; set; }

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("planId")]
    public string? PlanId { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("scheduleParameters")]
    public List<ScheduleCreationParameterModel>? ScheduleParameters { get; set; }

    [JsonPropertyName("size")]
    public string? Size { get; set; }

    [JsonPropertyName("sshKey")]
    public string? SshKey { get; set; }

    [JsonPropertyName("storageType")]
    public string? StorageType { get; set; }

    [JsonPropertyName("uniqueIdentifier")]
    public string? UniqueIdentifier { get; set; }

    [JsonPropertyName("userName")]
    public string? UserName { get; set; }

    [JsonPropertyName("virtualMachineCreationSource")]
    public VirtualMachineCreationSourceConstant? VirtualMachineCreationSource { get; set; }
}
