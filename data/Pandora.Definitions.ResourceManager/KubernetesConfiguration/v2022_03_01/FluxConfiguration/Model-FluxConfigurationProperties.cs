using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2022_03_01.FluxConfiguration;


internal class FluxConfigurationPropertiesModel
{
    [JsonPropertyName("bucket")]
    public BucketDefinitionModel? Bucket { get; set; }

    [JsonPropertyName("complianceState")]
    public FluxComplianceStateConstant? ComplianceState { get; set; }

    [JsonPropertyName("configurationProtectedSettings")]
    public Dictionary<string, string>? ConfigurationProtectedSettings { get; set; }

    [JsonPropertyName("errorMessage")]
    public string? ErrorMessage { get; set; }

    [JsonPropertyName("gitRepository")]
    public GitRepositoryDefinitionModel? GitRepository { get; set; }

    [JsonPropertyName("kustomizations")]
    public Dictionary<string, KustomizationDefinitionModel>? Kustomizations { get; set; }

    [JsonPropertyName("namespace")]
    public string? Namespace { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("repositoryPublicKey")]
    public string? RepositoryPublicKey { get; set; }

    [JsonPropertyName("scope")]
    public ScopeTypeConstant? Scope { get; set; }

    [JsonPropertyName("sourceKind")]
    public SourceKindTypeConstant? SourceKind { get; set; }

    [JsonPropertyName("sourceSyncedCommitId")]
    public string? SourceSyncedCommitId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("sourceUpdatedAt")]
    public DateTime? SourceUpdatedAt { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("statusUpdatedAt")]
    public DateTime? StatusUpdatedAt { get; set; }

    [JsonPropertyName("statuses")]
    public List<ObjectStatusDefinitionModel>? Statuses { get; set; }

    [JsonPropertyName("suspend")]
    public bool? Suspend { get; set; }
}
