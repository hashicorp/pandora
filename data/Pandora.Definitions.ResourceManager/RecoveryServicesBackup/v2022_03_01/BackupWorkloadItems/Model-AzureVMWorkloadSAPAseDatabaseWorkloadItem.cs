using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_03_01.BackupWorkloadItems;

[ValueForType("SAPAseDatabase")]
internal class AzureVMWorkloadSAPAseDatabaseWorkloadItemModel : WorkloadItemModel
{
    [JsonPropertyName("isAutoProtectable")]
    public bool? IsAutoProtectable { get; set; }

    [JsonPropertyName("parentName")]
    public string? ParentName { get; set; }

    [JsonPropertyName("serverName")]
    public string? ServerName { get; set; }

    [JsonPropertyName("subWorkloadItemCount")]
    public int? SubWorkloadItemCount { get; set; }

    [JsonPropertyName("subinquireditemcount")]
    public int? Subinquireditemcount { get; set; }
}
