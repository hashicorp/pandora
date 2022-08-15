using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.AssetsAndAssetFilters;


internal class PresentationTimeRangeModel
{
    [JsonPropertyName("endTimestamp")]
    public int? EndTimestamp { get; set; }

    [JsonPropertyName("forceEndTimestamp")]
    public bool? ForceEndTimestamp { get; set; }

    [JsonPropertyName("liveBackoffDuration")]
    public int? LiveBackoffDuration { get; set; }

    [JsonPropertyName("presentationWindowDuration")]
    public int? PresentationWindowDuration { get; set; }

    [JsonPropertyName("startTimestamp")]
    public int? StartTimestamp { get; set; }

    [JsonPropertyName("timescale")]
    public int? Timescale { get; set; }
}
