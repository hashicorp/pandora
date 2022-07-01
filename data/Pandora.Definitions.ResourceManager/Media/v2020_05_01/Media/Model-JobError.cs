using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.Media;


internal class JobErrorModel
{
    [JsonPropertyName("category")]
    public JobErrorCategoryConstant? Category { get; set; }

    [JsonPropertyName("code")]
    public JobErrorCodeConstant? Code { get; set; }

    [JsonPropertyName("details")]
    public List<JobErrorDetailModel>? Details { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("retry")]
    public JobRetryConstant? Retry { get; set; }
}
