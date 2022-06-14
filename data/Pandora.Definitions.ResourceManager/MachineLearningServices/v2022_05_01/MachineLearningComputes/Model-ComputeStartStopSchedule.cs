using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.MachineLearningComputes;


internal class ComputeStartStopScheduleModel
{
    [JsonPropertyName("action")]
    public ComputePowerActionConstant? Action { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("provisioningStatus")]
    public ProvisioningStatusConstant? ProvisioningStatus { get; set; }

    [JsonPropertyName("schedule")]
    public ScheduleBaseModel? Schedule { get; set; }
}
