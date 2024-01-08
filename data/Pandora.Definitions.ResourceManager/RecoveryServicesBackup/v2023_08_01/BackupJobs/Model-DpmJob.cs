using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_08_01.BackupJobs;

[ValueForType("DpmJob")]
internal class DpmJobModel : JobModel
{
    [JsonPropertyName("actionsInfo")]
    public List<JobSupportedActionConstant>? ActionsInfo { get; set; }

    [JsonPropertyName("containerName")]
    public string? ContainerName { get; set; }

    [JsonPropertyName("containerType")]
    public string? ContainerType { get; set; }

    [JsonPropertyName("dpmServerName")]
    public string? DpmServerName { get; set; }

    [JsonPropertyName("duration")]
    public string? Duration { get; set; }

    [JsonPropertyName("errorDetails")]
    public List<DpmErrorInfoModel>? ErrorDetails { get; set; }

    [JsonPropertyName("extendedInfo")]
    public DpmJobExtendedInfoModel? ExtendedInfo { get; set; }

    [JsonPropertyName("workloadType")]
    public string? WorkloadType { get; set; }
}
