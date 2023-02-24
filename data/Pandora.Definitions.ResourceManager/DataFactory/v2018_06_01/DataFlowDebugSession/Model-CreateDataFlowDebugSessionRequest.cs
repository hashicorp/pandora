using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.DataFlowDebugSession;


internal class CreateDataFlowDebugSessionRequestModel
{
    [JsonPropertyName("computeType")]
    public string? ComputeType { get; set; }

    [JsonPropertyName("coreCount")]
    public int? CoreCount { get; set; }

    [JsonPropertyName("integrationRuntime")]
    public IntegrationRuntimeDebugResourceModel? IntegrationRuntime { get; set; }

    [JsonPropertyName("timeToLive")]
    public int? TimeToLive { get; set; }
}
