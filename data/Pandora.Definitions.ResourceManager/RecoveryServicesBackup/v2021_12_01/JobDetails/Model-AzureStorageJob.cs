using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2021_12_01.JobDetails;

[ValueForType("AzureStorageJob")]
internal class AzureStorageJobModel : JobModel
{
    [JsonPropertyName("actionsInfo")]
    public List<JobSupportedActionConstant>? ActionsInfo { get; set; }

    [JsonPropertyName("duration")]
    public string? Duration { get; set; }

    [JsonPropertyName("errorDetails")]
    public List<AzureStorageErrorInfoModel>? ErrorDetails { get; set; }

    [JsonPropertyName("extendedInfo")]
    public AzureStorageJobExtendedInfoModel? ExtendedInfo { get; set; }

    [JsonPropertyName("isUserTriggered")]
    public bool? IsUserTriggered { get; set; }

    [JsonPropertyName("storageAccountName")]
    public string? StorageAccountName { get; set; }

    [JsonPropertyName("storageAccountVersion")]
    public string? StorageAccountVersion { get; set; }
}
