// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class GroupPrintUsageSummaryModel
{
    [JsonPropertyName("completedJobCount")]
    public int? CompletedJobCount { get; set; }

    [JsonPropertyName("group")]
    public IdentityModel? Group { get; set; }

    [JsonPropertyName("groupDisplayName")]
    public string? GroupDisplayName { get; set; }

    [JsonPropertyName("groupMail")]
    public string? GroupMail { get; set; }

    [JsonPropertyName("incompleteJobCount")]
    public int? IncompleteJobCount { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
