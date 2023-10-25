using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.ManagedInstances;


internal class RefreshExternalGovernanceStatusOperationResultPropertiesMIModel
{
    [JsonPropertyName("errorMessage")]
    public string? ErrorMessage { get; set; }

    [JsonPropertyName("managedInstanceName")]
    public string? ManagedInstanceName { get; set; }

    [JsonPropertyName("queuedTime")]
    public string? QueuedTime { get; set; }

    [JsonPropertyName("requestId")]
    public string? RequestId { get; set; }

    [JsonPropertyName("requestType")]
    public string? RequestType { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
