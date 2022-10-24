using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2022_01_01.Pool;


internal class PoolPropertiesModel
{
    [JsonPropertyName("allocationState")]
    public AllocationStateConstant? AllocationState { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("allocationStateTransitionTime")]
    public DateTime? AllocationStateTransitionTime { get; set; }

    [JsonPropertyName("applicationLicenses")]
    public List<string>? ApplicationLicenses { get; set; }

    [JsonPropertyName("applicationPackages")]
    public List<ApplicationPackageReferenceModel>? ApplicationPackages { get; set; }

    [JsonPropertyName("autoScaleRun")]
    public AutoScaleRunModel? AutoScaleRun { get; set; }

    [JsonPropertyName("certificates")]
    public List<CertificateReferenceModel>? Certificates { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("creationTime")]
    public DateTime? CreationTime { get; set; }

    [JsonPropertyName("currentDedicatedNodes")]
    public int? CurrentDedicatedNodes { get; set; }

    [JsonPropertyName("currentLowPriorityNodes")]
    public int? CurrentLowPriorityNodes { get; set; }

    [JsonPropertyName("deploymentConfiguration")]
    public DeploymentConfigurationModel? DeploymentConfiguration { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("interNodeCommunication")]
    public InterNodeCommunicationStateConstant? InterNodeCommunication { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModified")]
    public DateTime? LastModified { get; set; }

    [JsonPropertyName("metadata")]
    public List<MetadataItemModel>? Metadata { get; set; }

    [JsonPropertyName("mountConfiguration")]
    public List<MountConfigurationModel>? MountConfiguration { get; set; }

    [JsonPropertyName("networkConfiguration")]
    public NetworkConfigurationModel? NetworkConfiguration { get; set; }

    [JsonPropertyName("provisioningState")]
    public PoolProvisioningStateConstant? ProvisioningState { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("provisioningStateTransitionTime")]
    public DateTime? ProvisioningStateTransitionTime { get; set; }

    [JsonPropertyName("resizeOperationStatus")]
    public ResizeOperationStatusModel? ResizeOperationStatus { get; set; }

    [JsonPropertyName("scaleSettings")]
    public ScaleSettingsModel? ScaleSettings { get; set; }

    [JsonPropertyName("startTask")]
    public StartTaskModel? StartTask { get; set; }

    [JsonPropertyName("taskSchedulingPolicy")]
    public TaskSchedulingPolicyModel? TaskSchedulingPolicy { get; set; }

    [JsonPropertyName("taskSlotsPerNode")]
    public int? TaskSlotsPerNode { get; set; }

    [JsonPropertyName("userAccounts")]
    public List<UserAccountModel>? UserAccounts { get; set; }

    [JsonPropertyName("vmSize")]
    public string? VmSize { get; set; }
}
