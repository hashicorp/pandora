using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2023_09_01.DeletedWorkspaces;


internal class WorkspaceCappingModel
{
    [JsonPropertyName("dailyQuotaGb")]
    public float? DailyQuotaGb { get; set; }

    [JsonPropertyName("dataIngestionStatus")]
    public DataIngestionStatusConstant? DataIngestionStatus { get; set; }

    [JsonPropertyName("quotaNextResetTime")]
    public string? QuotaNextResetTime { get; set; }
}
