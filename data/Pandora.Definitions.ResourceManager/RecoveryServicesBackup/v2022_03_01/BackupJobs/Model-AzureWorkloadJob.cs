using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_03_01.BackupJobs;

[ValueForType("AzureWorkloadJob")]
internal class AzureWorkloadJobModel : JobModel
{
    [JsonPropertyName("actionsInfo")]
    public List<JobSupportedActionConstant>? ActionsInfo { get; set; }

    [JsonPropertyName("duration")]
    public string? Duration { get; set; }

    [JsonPropertyName("errorDetails")]
    public List<AzureWorkloadErrorInfoModel>? ErrorDetails { get; set; }

    [JsonPropertyName("extendedInfo")]
    public AzureWorkloadJobExtendedInfoModel? ExtendedInfo { get; set; }

    [JsonPropertyName("workloadType")]
    public string? WorkloadType { get; set; }
}
