using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.AppServiceEnvironments;


internal class StatusCodesRangeBasedTriggerModel
{
    [JsonPropertyName("count")]
    public int? Count { get; set; }

    [JsonPropertyName("path")]
    public string? Path { get; set; }

    [JsonPropertyName("statusCodes")]
    public string? StatusCodes { get; set; }

    [JsonPropertyName("timeInterval")]
    public string? TimeInterval { get; set; }
}
