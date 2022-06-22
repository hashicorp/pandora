using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2021_06_22.HybridRunbookWorker;


internal class HybridRunbookWorkerPropertiesModel
{
    [JsonPropertyName("ip")]
    public string? Ip { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastSeenDateTime")]
    public DateTime? LastSeenDateTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("registeredDateTime")]
    public DateTime? RegisteredDateTime { get; set; }

    [JsonPropertyName("vmResourceId")]
    public string? VmResourceId { get; set; }

    [JsonPropertyName("workerName")]
    public string? WorkerName { get; set; }

    [JsonPropertyName("workerType")]
    public WorkerTypeConstant? WorkerType { get; set; }
}
