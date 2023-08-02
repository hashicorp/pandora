// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ProcessModel
{
    [JsonPropertyName("accountName")]
    public string? AccountName { get; set; }

    [JsonPropertyName("commandLine")]
    public string? CommandLine { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("fileHash")]
    public FileHashModel? FileHash { get; set; }

    [JsonPropertyName("integrityLevel")]
    public ProcessIntegrityLevelConstant? IntegrityLevel { get; set; }

    [JsonPropertyName("isElevated")]
    public bool? IsElevated { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("parentProcessCreatedDateTime")]
    public DateTime? ParentProcessCreatedDateTime { get; set; }

    [JsonPropertyName("parentProcessId")]
    public int? ParentProcessId { get; set; }

    [JsonPropertyName("parentProcessName")]
    public string? ParentProcessName { get; set; }

    [JsonPropertyName("path")]
    public string? Path { get; set; }

    [JsonPropertyName("processId")]
    public int? ProcessId { get; set; }
}
