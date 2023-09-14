using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.ImportJobsController;


internal class ImportMachinesJobPropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("blobCreationTimeStamp")]
    public DateTime? BlobCreationTimeStamp { get; set; }

    [JsonPropertyName("blobName")]
    public string? BlobName { get; set; }

    [JsonPropertyName("blobSasUri")]
    public string? BlobSasUri { get; set; }

    [JsonPropertyName("errorSummary")]
    public JobErrorSummaryModel? ErrorSummary { get; set; }

    [JsonPropertyName("jobResult")]
    public JobResultConstant? JobResult { get; set; }

    [JsonPropertyName("numberOfMachinesImported")]
    public int? NumberOfMachinesImported { get; set; }
}
