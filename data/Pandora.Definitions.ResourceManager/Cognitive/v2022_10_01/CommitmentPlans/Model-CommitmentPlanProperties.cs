using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Cognitive.v2022_10_01.CommitmentPlans;


internal class CommitmentPlanPropertiesModel
{
    [JsonPropertyName("autoRenew")]
    public bool? AutoRenew { get; set; }

    [JsonPropertyName("current")]
    public CommitmentPeriodModel? Current { get; set; }

    [JsonPropertyName("hostingModel")]
    public HostingModelConstant? HostingModel { get; set; }

    [JsonPropertyName("last")]
    public CommitmentPeriodModel? Last { get; set; }

    [JsonPropertyName("next")]
    public CommitmentPeriodModel? Next { get; set; }

    [JsonPropertyName("planType")]
    public string? PlanType { get; set; }
}
