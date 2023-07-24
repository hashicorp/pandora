using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;


internal class RestoreRequestPropertiesModel
{
    [JsonPropertyName("adjustConnectionStrings")]
    public bool? AdjustConnectionStrings { get; set; }

    [JsonPropertyName("appServicePlan")]
    public string? AppServicePlan { get; set; }

    [JsonPropertyName("blobName")]
    public string? BlobName { get; set; }

    [JsonPropertyName("databases")]
    public List<DatabaseBackupSettingModel>? Databases { get; set; }

    [JsonPropertyName("hostingEnvironment")]
    public string? HostingEnvironment { get; set; }

    [JsonPropertyName("ignoreConflictingHostNames")]
    public bool? IgnoreConflictingHostNames { get; set; }

    [JsonPropertyName("ignoreDatabases")]
    public bool? IgnoreDatabases { get; set; }

    [JsonPropertyName("operationType")]
    public BackupRestoreOperationTypeConstant? OperationType { get; set; }

    [JsonPropertyName("overwrite")]
    [Required]
    public bool Overwrite { get; set; }

    [JsonPropertyName("siteName")]
    public string? SiteName { get; set; }

    [JsonPropertyName("storageAccountUrl")]
    [Required]
    public string StorageAccountUrl { get; set; }
}
