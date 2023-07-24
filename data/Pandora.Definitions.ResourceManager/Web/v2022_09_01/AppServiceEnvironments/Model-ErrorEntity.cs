using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.AppServiceEnvironments;


internal class ErrorEntityModel
{
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("details")]
    public List<ErrorEntityModel>? Details { get; set; }

    [JsonPropertyName("extendedCode")]
    public string? ExtendedCode { get; set; }

    [JsonPropertyName("innerErrors")]
    public List<ErrorEntityModel>? InnerErrors { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("messageTemplate")]
    public string? MessageTemplate { get; set; }

    [JsonPropertyName("parameters")]
    public List<string>? Parameters { get; set; }

    [JsonPropertyName("target")]
    public string? Target { get; set; }
}
