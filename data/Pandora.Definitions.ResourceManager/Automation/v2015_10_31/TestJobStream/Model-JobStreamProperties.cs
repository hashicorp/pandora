using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2015_10_31.TestJobStream;


internal class JobStreamPropertiesModel
{
    [JsonPropertyName("jobStreamId")]
    public string? JobStreamId { get; set; }

    [JsonPropertyName("streamText")]
    public string? StreamText { get; set; }

    [JsonPropertyName("streamType")]
    public JobStreamTypeConstant? StreamType { get; set; }

    [JsonPropertyName("summary")]
    public string? Summary { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("time")]
    public DateTime? Time { get; set; }

    [JsonPropertyName("value")]
    public Dictionary<string, object>? Value { get; set; }
}
