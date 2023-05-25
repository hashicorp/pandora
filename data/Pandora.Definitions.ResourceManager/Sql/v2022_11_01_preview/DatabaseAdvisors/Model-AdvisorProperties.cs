using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.DatabaseAdvisors;


internal class AdvisorPropertiesModel
{
    [JsonPropertyName("advisorStatus")]
    public AdvisorStatusConstant? AdvisorStatus { get; set; }

    [JsonPropertyName("autoExecuteStatus")]
    [Required]
    public AutoExecuteStatusConstant AutoExecuteStatus { get; set; }

    [JsonPropertyName("autoExecuteStatusInheritedFrom")]
    public AutoExecuteStatusInheritedFromConstant? AutoExecuteStatusInheritedFrom { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastChecked")]
    public DateTime? LastChecked { get; set; }

    [JsonPropertyName("recommendationsStatus")]
    public string? RecommendationsStatus { get; set; }

    [JsonPropertyName("recommendedActions")]
    public List<RecommendedActionModel>? RecommendedActions { get; set; }
}
