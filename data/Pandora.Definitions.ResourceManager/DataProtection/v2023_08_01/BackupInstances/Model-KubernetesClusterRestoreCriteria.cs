using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_08_01.BackupInstances;

[ValueForType("KubernetesClusterRestoreCriteria")]
internal class KubernetesClusterRestoreCriteriaModel : ItemLevelRestoreCriteriaModel
{
    [JsonPropertyName("conflictPolicy")]
    public ExistingResourcePolicyConstant? ConflictPolicy { get; set; }

    [JsonPropertyName("excludedNamespaces")]
    public List<string>? ExcludedNamespaces { get; set; }

    [JsonPropertyName("excludedResourceTypes")]
    public List<string>? ExcludedResourceTypes { get; set; }

    [JsonPropertyName("includeClusterScopeResources")]
    [Required]
    public bool IncludeClusterScopeResources { get; set; }

    [JsonPropertyName("includedNamespaces")]
    public List<string>? IncludedNamespaces { get; set; }

    [JsonPropertyName("includedResourceTypes")]
    public List<string>? IncludedResourceTypes { get; set; }

    [JsonPropertyName("labelSelectors")]
    public List<string>? LabelSelectors { get; set; }

    [JsonPropertyName("namespaceMappings")]
    public Dictionary<string, string>? NamespaceMappings { get; set; }

    [JsonPropertyName("persistentVolumeRestoreMode")]
    public PersistentVolumeRestoreModeConstant? PersistentVolumeRestoreMode { get; set; }

    [JsonPropertyName("restoreHookReferences")]
    public List<NamespacedNameResourceModel>? RestoreHookReferences { get; set; }
}
