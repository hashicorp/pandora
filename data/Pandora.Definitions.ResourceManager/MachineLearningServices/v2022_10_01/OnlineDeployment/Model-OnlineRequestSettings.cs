using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.OnlineDeployment;


internal class OnlineRequestSettingsModel
{
    [JsonPropertyName("maxConcurrentRequestsPerInstance")]
    public int? MaxConcurrentRequestsPerInstance { get; set; }

    [JsonPropertyName("maxQueueWait")]
    public string? MaxQueueWait { get; set; }

    [JsonPropertyName("requestTimeout")]
    public string? RequestTimeout { get; set; }
}
