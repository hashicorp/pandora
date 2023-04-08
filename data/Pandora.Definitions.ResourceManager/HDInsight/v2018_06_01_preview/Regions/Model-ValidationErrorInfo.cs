using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HDInsight.v2018_06_01_preview.Regions;


internal class ValidationErrorInfoModel
{
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("errorResource")]
    public string? ErrorResource { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("messageArguments")]
    public List<string>? MessageArguments { get; set; }
}
