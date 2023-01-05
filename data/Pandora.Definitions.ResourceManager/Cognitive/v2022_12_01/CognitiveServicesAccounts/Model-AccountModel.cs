using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Cognitive.v2022_12_01.CognitiveServicesAccounts;


internal class AccountModelModel
{
    [JsonPropertyName("baseModel")]
    public DeploymentModelModel? BaseModel { get; set; }

    [JsonPropertyName("callRateLimit")]
    public CallRateLimitModel? CallRateLimit { get; set; }

    [JsonPropertyName("capabilities")]
    public Dictionary<string, string>? Capabilities { get; set; }

    [JsonPropertyName("deprecation")]
    public ModelDeprecationInfoModel? Deprecation { get; set; }

    [JsonPropertyName("finetuneCapabilities")]
    public Dictionary<string, string>? FinetuneCapabilities { get; set; }

    [JsonPropertyName("format")]
    public string? Format { get; set; }

    [JsonPropertyName("lifecycleStatus")]
    public ModelLifecycleStatusConstant? LifecycleStatus { get; set; }

    [JsonPropertyName("maxCapacity")]
    public int? MaxCapacity { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("systemData")]
    public CustomTypes.SystemData? SystemData { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
