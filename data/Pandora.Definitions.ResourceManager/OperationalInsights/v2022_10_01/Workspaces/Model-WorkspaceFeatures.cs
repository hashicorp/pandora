using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2022_10_01.Workspaces;


internal class WorkspaceFeaturesModel
{
    [JsonPropertyName("clusterResourceId")]
    public string? ClusterResourceId { get; set; }

    [JsonPropertyName("disableLocalAuth")]
    public bool? DisableLocalAuth { get; set; }

    [JsonPropertyName("enableDataExport")]
    public bool? EnableDataExport { get; set; }

    [JsonPropertyName("enableLogAccessUsingOnlyResourcePermissions")]
    public bool? EnableLogAccessUsingOnlyResourcePermissions { get; set; }

    [JsonPropertyName("immediatePurgeDataOn30Days")]
    public bool? ImmediatePurgeDataOn30Days { get; set; }
}
