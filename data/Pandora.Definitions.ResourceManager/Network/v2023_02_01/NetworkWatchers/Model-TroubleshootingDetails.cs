using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.NetworkWatchers;


internal class TroubleshootingDetailsModel
{
    [JsonPropertyName("detail")]
    public string? Detail { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("reasonType")]
    public string? ReasonType { get; set; }

    [JsonPropertyName("recommendedActions")]
    public List<TroubleshootingRecommendedActionsModel>? RecommendedActions { get; set; }

    [JsonPropertyName("summary")]
    public string? Summary { get; set; }
}
