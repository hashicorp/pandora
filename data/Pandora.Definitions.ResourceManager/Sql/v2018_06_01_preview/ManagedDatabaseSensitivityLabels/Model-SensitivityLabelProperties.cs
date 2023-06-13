using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2018_06_01_preview.ManagedDatabaseSensitivityLabels;


internal class SensitivityLabelPropertiesModel
{
    [JsonPropertyName("informationType")]
    public string? InformationType { get; set; }

    [JsonPropertyName("informationTypeId")]
    public string? InformationTypeId { get; set; }

    [JsonPropertyName("isDisabled")]
    public bool? IsDisabled { get; set; }

    [JsonPropertyName("labelId")]
    public string? LabelId { get; set; }

    [JsonPropertyName("labelName")]
    public string? LabelName { get; set; }

    [JsonPropertyName("rank")]
    public SensitivityLabelRankConstant? Rank { get; set; }
}
