using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagedApplications.v2019_07_01.ApplicationDefinitions;


internal class ApplicationDefinitionPropertiesModel
{
    [JsonPropertyName("artifacts")]
    public List<ApplicationDefinitionArtifactModel>? Artifacts { get; set; }

    [JsonPropertyName("authorizations")]
    public List<ApplicationAuthorizationModel>? Authorizations { get; set; }

    [JsonPropertyName("createUiDefinition")]
    public object? CreateUiDefinition { get; set; }

    [JsonPropertyName("deploymentPolicy")]
    public ApplicationDeploymentPolicyModel? DeploymentPolicy { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("isEnabled")]
    public bool? IsEnabled { get; set; }

    [JsonPropertyName("lockLevel")]
    [Required]
    public ApplicationLockLevelConstant LockLevel { get; set; }

    [JsonPropertyName("lockingPolicy")]
    public ApplicationPackageLockingPolicyDefinitionModel? LockingPolicy { get; set; }

    [JsonPropertyName("mainTemplate")]
    public object? MainTemplate { get; set; }

    [JsonPropertyName("managementPolicy")]
    public ApplicationManagementPolicyModel? ManagementPolicy { get; set; }

    [JsonPropertyName("notificationPolicy")]
    public ApplicationNotificationPolicyModel? NotificationPolicy { get; set; }

    [JsonPropertyName("packageFileUri")]
    public string? PackageFileUri { get; set; }

    [JsonPropertyName("policies")]
    public List<ApplicationPolicyModel>? Policies { get; set; }

    [JsonPropertyName("storageAccountId")]
    public string? StorageAccountId { get; set; }
}
