using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Kusto.v2022_02_01.AttachedDatabaseConfigurations;


internal class CheckNameResultModel
{
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("nameAvailable")]
    public bool? NameAvailable { get; set; }

    [JsonPropertyName("reason")]
    public ReasonConstant? Reason { get; set; }
}
