using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_01_15.CrossRegionRestore;

[ValueForType("WorkloadCrrAccessToken")]
internal class WorkloadCrrAccessTokenModel : CrrAccessTokenModel
{
    [JsonPropertyName("containerId")]
    public string? ContainerId { get; set; }

    [JsonPropertyName("policyId")]
    public string? PolicyId { get; set; }

    [JsonPropertyName("policyName")]
    public string? PolicyName { get; set; }

    [JsonPropertyName("protectableObjectContainerHostOsName")]
    public string? ProtectableObjectContainerHostOsName { get; set; }

    [JsonPropertyName("protectableObjectFriendlyName")]
    public string? ProtectableObjectFriendlyName { get; set; }

    [JsonPropertyName("protectableObjectParentLogicalContainerName")]
    public string? ProtectableObjectParentLogicalContainerName { get; set; }

    [JsonPropertyName("protectableObjectProtectionState")]
    public string? ProtectableObjectProtectionState { get; set; }

    [JsonPropertyName("protectableObjectUniqueName")]
    public string? ProtectableObjectUniqueName { get; set; }

    [JsonPropertyName("protectableObjectWorkloadType")]
    public string? ProtectableObjectWorkloadType { get; set; }
}
