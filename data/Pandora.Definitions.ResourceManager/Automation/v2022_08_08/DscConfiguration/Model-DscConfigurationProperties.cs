using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2022_08_08.DscConfiguration;


internal class DscConfigurationPropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("creationTime")]
    public DateTime? CreationTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("jobCount")]
    public int? JobCount { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModifiedTime")]
    public DateTime? LastModifiedTime { get; set; }

    [JsonPropertyName("logVerbose")]
    public bool? LogVerbose { get; set; }

    [JsonPropertyName("nodeConfigurationCount")]
    public int? NodeConfigurationCount { get; set; }

    [JsonPropertyName("parameters")]
    public Dictionary<string, DscConfigurationParameterModel>? Parameters { get; set; }

    [JsonPropertyName("provisioningState")]
    public DscConfigurationProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("source")]
    public ContentSourceModel? Source { get; set; }

    [JsonPropertyName("state")]
    public DscConfigurationStateConstant? State { get; set; }
}
