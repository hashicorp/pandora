// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class Win32LobAppFileSystemRequirementModel
{
    [JsonPropertyName("check32BitOn64System")]
    public bool? Check32BitOn64System { get; set; }

    [JsonPropertyName("detectionType")]
    public Win32LobAppFileSystemRequirementDetectionTypeConstant? DetectionType { get; set; }

    [JsonPropertyName("detectionValue")]
    public string? DetectionValue { get; set; }

    [JsonPropertyName("fileOrFolderName")]
    public string? FileOrFolderName { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operator")]
    public Win32LobAppFileSystemRequirementOperatorConstant? Operator { get; set; }

    [JsonPropertyName("path")]
    public string? Path { get; set; }
}
