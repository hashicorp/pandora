using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ResourceGraph.v2022_10_01.Resources;


internal class QueryRequestOptionsModel
{
    [JsonPropertyName("allowPartialScopes")]
    public bool? AllowPartialScopes { get; set; }

    [JsonPropertyName("authorizationScopeFilter")]
    public AuthorizationScopeFilterConstant? AuthorizationScopeFilter { get; set; }

    [JsonPropertyName("resultFormat")]
    public ResultFormatConstant? ResultFormat { get; set; }

    [JsonPropertyName("$skip")]
    public int? Skip { get; set; }

    [JsonPropertyName("$skipToken")]
    public string? SkipToken { get; set; }

    [JsonPropertyName("$top")]
    public int? Top { get; set; }
}
