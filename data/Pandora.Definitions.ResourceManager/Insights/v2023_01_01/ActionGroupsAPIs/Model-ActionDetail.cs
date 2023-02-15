using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2023_01_01.ActionGroupsAPIs;


internal class ActionDetailModel
{
    [JsonPropertyName("Detail")]
    public string? Detail { get; set; }

    [JsonPropertyName("MechanismType")]
    public string? MechanismType { get; set; }

    [JsonPropertyName("Name")]
    public string? Name { get; set; }

    [JsonPropertyName("SendTime")]
    public string? SendTime { get; set; }

    [JsonPropertyName("Status")]
    public string? Status { get; set; }

    [JsonPropertyName("SubState")]
    public string? SubState { get; set; }
}
