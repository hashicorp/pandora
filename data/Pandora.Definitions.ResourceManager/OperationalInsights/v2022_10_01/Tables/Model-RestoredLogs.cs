using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2022_10_01.Tables;


internal class RestoredLogsModel
{
    [JsonPropertyName("azureAsyncOperationId")]
    public string? AzureAsyncOperationId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endRestoreTime")]
    public DateTime? EndRestoreTime { get; set; }

    [JsonPropertyName("sourceTable")]
    public string? SourceTable { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startRestoreTime")]
    public DateTime? StartRestoreTime { get; set; }
}
