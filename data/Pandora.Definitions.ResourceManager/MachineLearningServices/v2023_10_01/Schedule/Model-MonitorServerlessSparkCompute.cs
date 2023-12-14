using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.Schedule;

[ValueForType("ServerlessSpark")]
internal class MonitorServerlessSparkComputeModel : MonitorComputeConfigurationBaseModel
{
    [JsonPropertyName("computeIdentity")]
    [Required]
    public MonitorComputeIdentityBaseModel ComputeIdentity { get; set; }

    [JsonPropertyName("instanceType")]
    [Required]
    public string InstanceType { get; set; }

    [JsonPropertyName("runtimeVersion")]
    [Required]
    public string RuntimeVersion { get; set; }
}
