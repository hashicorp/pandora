using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2022_10_01.Workspaces;


internal class WorkspaceSkuModel
{
    [JsonPropertyName("capacityReservationLevel")]
    public CapacityReservationLevelConstant? CapacityReservationLevel { get; set; }

    [JsonPropertyName("lastSkuUpdate")]
    public string? LastSkuUpdate { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public WorkspaceSkuNameEnumConstant Name { get; set; }
}
