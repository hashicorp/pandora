using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2019_05_05_preview.AlertsManagements;


internal class AlertsSummaryGroupModel
{
    [JsonPropertyName("groupedby")]
    public string? Groupedby { get; set; }

    [JsonPropertyName("smartGroupsCount")]
    public int? SmartGroupsCount { get; set; }

    [JsonPropertyName("total")]
    public int? Total { get; set; }

    [JsonPropertyName("values")]
    public List<AlertsSummaryGroupItemModel>? Values { get; set; }
}
