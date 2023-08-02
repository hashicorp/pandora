using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Job;

[ValueForType("Ray")]
internal class RayModel : DistributionConfigurationModel
{
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("dashboardPort")]
    public int? DashboardPort { get; set; }

    [JsonPropertyName("headNodeAdditionalArgs")]
    public string? HeadNodeAdditionalArgs { get; set; }

    [JsonPropertyName("includeDashboard")]
    public bool? IncludeDashboard { get; set; }

    [JsonPropertyName("port")]
    public int? Port { get; set; }

    [JsonPropertyName("workerNodeAdditionalArgs")]
    public string? WorkerNodeAdditionalArgs { get; set; }
}
