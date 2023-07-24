using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;


internal class FunctionEnvelopePropertiesModel
{
    [JsonPropertyName("config")]
    public object? Config { get; set; }

    [JsonPropertyName("config_href")]
    public string? ConfigHref { get; set; }

    [JsonPropertyName("files")]
    public Dictionary<string, string>? Files { get; set; }

    [JsonPropertyName("function_app_id")]
    public string? FunctionAppId { get; set; }

    [JsonPropertyName("href")]
    public string? Href { get; set; }

    [JsonPropertyName("invoke_url_template")]
    public string? InvokeUrlTemplate { get; set; }

    [JsonPropertyName("isDisabled")]
    public bool? IsDisabled { get; set; }

    [JsonPropertyName("language")]
    public string? Language { get; set; }

    [JsonPropertyName("script_href")]
    public string? ScriptHref { get; set; }

    [JsonPropertyName("script_root_path_href")]
    public string? ScriptRootPathHref { get; set; }

    [JsonPropertyName("secrets_file_href")]
    public string? SecretsFileHref { get; set; }

    [JsonPropertyName("test_data")]
    public string? TestData { get; set; }

    [JsonPropertyName("test_data_href")]
    public string? TestDataHref { get; set; }
}
