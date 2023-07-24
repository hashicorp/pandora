using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WorkflowRunActions;


internal class RunActionCorrelationModel
{
    [JsonPropertyName("actionTrackingId")]
    public string? ActionTrackingId { get; set; }

    [JsonPropertyName("clientKeywords")]
    public List<string>? ClientKeywords { get; set; }

    [JsonPropertyName("clientTrackingId")]
    public string? ClientTrackingId { get; set; }
}
