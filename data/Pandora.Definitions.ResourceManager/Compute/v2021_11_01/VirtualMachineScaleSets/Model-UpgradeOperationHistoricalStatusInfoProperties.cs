using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachineScaleSets;


internal class UpgradeOperationHistoricalStatusInfoPropertiesModel
{
    [JsonPropertyName("error")]
    public ApiErrorModel? Error { get; set; }

    [JsonPropertyName("progress")]
    public RollingUpgradeProgressInfoModel? Progress { get; set; }

    [JsonPropertyName("rollbackInfo")]
    public RollbackStatusInfoModel? RollbackInfo { get; set; }

    [JsonPropertyName("runningStatus")]
    public UpgradeOperationHistoryStatusModel? RunningStatus { get; set; }

    [JsonPropertyName("startedBy")]
    public UpgradeOperationInvokerConstant? StartedBy { get; set; }

    [JsonPropertyName("targetImageReference")]
    public ImageReferenceModel? TargetImageReference { get; set; }
}
