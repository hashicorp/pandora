using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PolicyInsights.v2023_03_01.CheckPolicyRestrictions;


internal class FieldRestrictionModel
{
    [JsonPropertyName("defaultValue")]
    public string? DefaultValue { get; set; }

    [JsonPropertyName("policy")]
    public PolicyReferenceModel? Policy { get; set; }

    [JsonPropertyName("policyEffect")]
    public string? PolicyEffect { get; set; }

    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    [JsonPropertyName("result")]
    public FieldRestrictionResultConstant? Result { get; set; }

    [JsonPropertyName("values")]
    public List<string>? Values { get; set; }
}
