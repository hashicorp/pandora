using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.Diagnostics;


internal class StatusModel
{
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("statusId")]
    public InsightStatusConstant? StatusId { get; set; }
}
