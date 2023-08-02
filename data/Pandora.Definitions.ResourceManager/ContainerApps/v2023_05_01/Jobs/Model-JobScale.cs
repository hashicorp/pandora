using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2023_05_01.Jobs;


internal class JobScaleModel
{
    [JsonPropertyName("maxExecutions")]
    public int? MaxExecutions { get; set; }

    [JsonPropertyName("minExecutions")]
    public int? MinExecutions { get; set; }

    [JsonPropertyName("pollingInterval")]
    public int? PollingInterval { get; set; }

    [JsonPropertyName("rules")]
    public List<JobScaleRuleModel>? Rules { get; set; }
}
