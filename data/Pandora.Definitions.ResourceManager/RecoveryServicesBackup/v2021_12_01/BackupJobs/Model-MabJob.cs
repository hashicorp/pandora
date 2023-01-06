using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2021_12_01.BackupJobs;

[ValueForType("MabJob")]
internal class MabJobModel : JobModel
{
    [JsonPropertyName("actionsInfo")]
    public List<JobSupportedActionConstant>? ActionsInfo { get; set; }

    [JsonPropertyName("duration")]
    public string? Duration { get; set; }

    [JsonPropertyName("errorDetails")]
    public List<MabErrorInfoModel>? ErrorDetails { get; set; }

    [JsonPropertyName("extendedInfo")]
    public MabJobExtendedInfoModel? ExtendedInfo { get; set; }

    [JsonPropertyName("mabServerName")]
    public string? MabServerName { get; set; }

    [JsonPropertyName("mabServerType")]
    public MabServerTypeConstant? MabServerType { get; set; }

    [JsonPropertyName("workloadType")]
    public WorkloadTypeConstant? WorkloadType { get; set; }
}
