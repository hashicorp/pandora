using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServices.v2022_09_10.ReplicationUsages;


internal class ReplicationUsageModel
{
    [JsonPropertyName("jobsSummary")]
    public JobsSummaryModel? JobsSummary { get; set; }

    [JsonPropertyName("monitoringSummary")]
    public MonitoringSummaryModel? MonitoringSummary { get; set; }

    [JsonPropertyName("protectedItemCount")]
    public int? ProtectedItemCount { get; set; }

    [JsonPropertyName("recoveryPlanCount")]
    public int? RecoveryPlanCount { get; set; }

    [JsonPropertyName("recoveryServicesProviderAuthType")]
    public int? RecoveryServicesProviderAuthType { get; set; }

    [JsonPropertyName("registeredServersCount")]
    public int? RegisteredServersCount { get; set; }
}
