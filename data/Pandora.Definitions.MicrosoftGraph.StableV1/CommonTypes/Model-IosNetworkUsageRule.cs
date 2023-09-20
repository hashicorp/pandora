// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class IosNetworkUsageRuleModel
{
    [JsonPropertyName("cellularDataBlockWhenRoaming")]
    public bool? CellularDataBlockWhenRoaming { get; set; }

    [JsonPropertyName("cellularDataBlocked")]
    public bool? CellularDataBlocked { get; set; }

    [JsonPropertyName("managedApps")]
    public List<AppListItemModel>? ManagedApps { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
