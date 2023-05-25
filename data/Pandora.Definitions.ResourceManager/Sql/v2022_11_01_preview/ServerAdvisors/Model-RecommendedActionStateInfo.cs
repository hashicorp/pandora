using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.ServerAdvisors;


internal class RecommendedActionStateInfoModel
{
    [JsonPropertyName("actionInitiatedBy")]
    public RecommendedActionInitiatedByConstant? ActionInitiatedBy { get; set; }

    [JsonPropertyName("currentValue")]
    [Required]
    public RecommendedActionCurrentStateConstant CurrentValue { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModified")]
    public DateTime? LastModified { get; set; }
}
