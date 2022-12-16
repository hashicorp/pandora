using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2021_10_01_preview.Subscriptions;


internal class SampleInputResultModel
{
    [JsonPropertyName("diagnostics")]
    public List<string>? Diagnostics { get; set; }

    [JsonPropertyName("error")]
    public ErrorErrorModel? Error { get; set; }

    [JsonPropertyName("eventsDownloadUrl")]
    public string? EventsDownloadUrl { get; set; }

    [JsonPropertyName("lastArrivalTime")]
    public string? LastArrivalTime { get; set; }

    [JsonPropertyName("status")]
    public SampleInputResultStatusConstant? Status { get; set; }
}
