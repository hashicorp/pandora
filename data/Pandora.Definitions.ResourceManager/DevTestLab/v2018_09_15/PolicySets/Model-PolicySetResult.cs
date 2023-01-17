using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.PolicySets;


internal class PolicySetResultModel
{
    [JsonPropertyName("hasError")]
    public bool? HasError { get; set; }

    [JsonPropertyName("policyViolations")]
    public List<PolicyViolationModel>? PolicyViolations { get; set; }
}
