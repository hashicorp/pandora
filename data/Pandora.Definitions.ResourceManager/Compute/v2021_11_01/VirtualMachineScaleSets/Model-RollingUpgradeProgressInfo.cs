using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_11_01.VirtualMachineScaleSets;


internal class RollingUpgradeProgressInfoModel
{
    [JsonPropertyName("failedInstanceCount")]
    public int? FailedInstanceCount { get; set; }

    [JsonPropertyName("inProgressInstanceCount")]
    public int? InProgressInstanceCount { get; set; }

    [JsonPropertyName("pendingInstanceCount")]
    public int? PendingInstanceCount { get; set; }

    [JsonPropertyName("successfulInstanceCount")]
    public int? SuccessfulInstanceCount { get; set; }
}
