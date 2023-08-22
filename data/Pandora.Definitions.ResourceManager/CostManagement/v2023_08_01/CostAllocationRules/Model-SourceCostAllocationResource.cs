using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2023_08_01.CostAllocationRules;


internal class SourceCostAllocationResourceModel
{
    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }

    [JsonPropertyName("resourceType")]
    [Required]
    public CostAllocationResourceTypeConstant ResourceType { get; set; }

    [JsonPropertyName("values")]
    [Required]
    public List<string> Values { get; set; }
}
