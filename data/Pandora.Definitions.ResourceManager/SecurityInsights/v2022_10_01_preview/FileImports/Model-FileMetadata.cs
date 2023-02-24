using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.FileImports;


internal class FileMetadataModel
{
    [JsonPropertyName("deleteStatus")]
    public DeleteStatusConstant? DeleteStatus { get; set; }

    [JsonPropertyName("fileContentUri")]
    public string? FileContentUri { get; set; }

    [JsonPropertyName("fileFormat")]
    public FileFormatConstant? FileFormat { get; set; }

    [JsonPropertyName("fileName")]
    public string? FileName { get; set; }

    [JsonPropertyName("fileSize")]
    public int? FileSize { get; set; }
}
