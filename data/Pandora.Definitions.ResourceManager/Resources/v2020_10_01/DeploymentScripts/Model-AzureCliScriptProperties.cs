using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2020_10_01.DeploymentScripts;


internal class AzureCliScriptPropertiesModel
{
    [JsonPropertyName("arguments")]
    public string? Arguments { get; set; }

    [JsonPropertyName("azCliVersion")]
    [Required]
    public string AzCliVersion { get; set; }

    [JsonPropertyName("cleanupPreference")]
    public CleanupOptionsConstant? CleanupPreference { get; set; }

    [JsonPropertyName("containerSettings")]
    public ContainerConfigurationModel? ContainerSettings { get; set; }

    [JsonPropertyName("environmentVariables")]
    public List<EnvironmentVariableModel>? EnvironmentVariables { get; set; }

    [JsonPropertyName("forceUpdateTag")]
    public string? ForceUpdateTag { get; set; }

    [JsonPropertyName("outputs")]
    public Dictionary<string, object>? Outputs { get; set; }

    [JsonPropertyName("primaryScriptUri")]
    public string? PrimaryScriptUri { get; set; }

    [JsonPropertyName("provisioningState")]
    public ScriptProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("retentionInterval")]
    [Required]
    public string RetentionInterval { get; set; }

    [JsonPropertyName("scriptContent")]
    public string? ScriptContent { get; set; }

    [JsonPropertyName("status")]
    public ScriptStatusModel? Status { get; set; }

    [JsonPropertyName("storageAccountSettings")]
    public StorageAccountConfigurationModel? StorageAccountSettings { get; set; }

    [JsonPropertyName("supportingScriptUris")]
    public List<string>? SupportingScriptUris { get; set; }

    [JsonPropertyName("timeout")]
    public string? Timeout { get; set; }
}
