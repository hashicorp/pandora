using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2021_10_01_preview.Subscriptions;


internal class QueryCompilationResultModel
{
    [JsonPropertyName("errors")]
    public List<QueryCompilationErrorModel>? Errors { get; set; }

    [JsonPropertyName("functions")]
    public List<string>? Functions { get; set; }

    [JsonPropertyName("inputs")]
    public List<string>? Inputs { get; set; }

    [JsonPropertyName("outputs")]
    public List<string>? Outputs { get; set; }

    [JsonPropertyName("warnings")]
    public List<string>? Warnings { get; set; }
}
