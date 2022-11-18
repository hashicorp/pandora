using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.Schedule;


internal class TableVerticalFeaturizationSettingsModel
{
    [JsonPropertyName("blockedTransformers")]
    public List<BlockedTransformersConstant>? BlockedTransformers { get; set; }

    [JsonPropertyName("columnNameAndTypes")]
    public Dictionary<string, string>? ColumnNameAndTypes { get; set; }

    [JsonPropertyName("datasetLanguage")]
    public string? DatasetLanguage { get; set; }

    [JsonPropertyName("enableDnnFeaturization")]
    public bool? EnableDnnFeaturization { get; set; }

    [JsonPropertyName("mode")]
    public FeaturizationModeConstant? Mode { get; set; }

    [JsonPropertyName("transformerParams")]
    public Dictionary<string, List<ColumnTransformerModel>>? TransformerParams { get; set; }
}
