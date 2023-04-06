using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_01_01.DeletedBackupInstances;

[ValueForType("KubernetesClusterBackupDatasourceParameters")]
internal class KubernetesClusterBackupDatasourceParametersModel : BackupDatasourceParametersModel
{
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

    [JsonPropertyName("snapshotVolumes")]
    [Required]
    public bool SnapshotVolumes { get; set; }
}
