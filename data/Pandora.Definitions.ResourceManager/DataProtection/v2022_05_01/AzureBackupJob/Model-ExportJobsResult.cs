using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_05_01.AzureBackupJob;


internal class ExportJobsResultModel
{
    [JsonPropertyName("blobSasKey")]
    public string? BlobSasKey { get; set; }

    [JsonPropertyName("blobUrl")]
    public string? BlobUrl { get; set; }

    [JsonPropertyName("excelFileBlobSasKey")]
    public string? ExcelFileBlobSasKey { get; set; }

    [JsonPropertyName("excelFileBlobUrl")]
    public string? ExcelFileBlobUrl { get; set; }
}
