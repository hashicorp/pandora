using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationJobs;


internal class JobErrorDetailsModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("creationTime")]
    public DateTime? CreationTime { get; set; }

    [JsonPropertyName("errorLevel")]
    public string? ErrorLevel { get; set; }

    [JsonPropertyName("providerErrorDetails")]
    public ProviderErrorModel? ProviderErrorDetails { get; set; }

    [JsonPropertyName("serviceErrorDetails")]
    public ServiceErrorModel? ServiceErrorDetails { get; set; }

    [JsonPropertyName("taskId")]
    public string? TaskId { get; set; }
}
