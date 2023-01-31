using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Jobs;


internal class JobPropertiesModel
{
    [JsonPropertyName("currentStage")]
    public UpdateOperationStageConstant? CurrentStage { get; set; }

    [JsonPropertyName("downloadProgress")]
    public UpdateDownloadProgressModel? DownloadProgress { get; set; }

    [JsonPropertyName("errorManifestFile")]
    public string? ErrorManifestFile { get; set; }

    [JsonPropertyName("folder")]
    public string? Folder { get; set; }

    [JsonPropertyName("installProgress")]
    public UpdateInstallProgressModel? InstallProgress { get; set; }

    [JsonPropertyName("jobType")]
    public JobTypeConstant? JobType { get; set; }

    [JsonPropertyName("refreshedEntityId")]
    public string? RefreshedEntityId { get; set; }

    [JsonPropertyName("totalRefreshErrors")]
    public int? TotalRefreshErrors { get; set; }
}
