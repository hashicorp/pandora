using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.ApiManagementService;


internal class ApiManagementServiceBackupRestoreParametersModel
{
    [JsonPropertyName("accessKey")]
    public string? AccessKey { get; set; }

    [JsonPropertyName("accessType")]
    public AccessTypeConstant? AccessType { get; set; }

    [JsonPropertyName("backupName")]
    [Required]
    public string BackupName { get; set; }

    [JsonPropertyName("clientId")]
    public string? ClientId { get; set; }

    [JsonPropertyName("containerName")]
    [Required]
    public string ContainerName { get; set; }

    [JsonPropertyName("storageAccount")]
    [Required]
    public string StorageAccount { get; set; }
}
