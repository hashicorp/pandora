using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.SqlDatabasesController;


internal class FileMetaDataModel
{
    [JsonPropertyName("fileType")]
    public FileTypeConstant? FileType { get; set; }

    [JsonPropertyName("isMemoryOptimizedDataOptionEnabled")]
    public bool? IsMemoryOptimizedDataOptionEnabled { get; set; }

    [JsonPropertyName("logicalName")]
    public string? LogicalName { get; set; }

    [JsonPropertyName("physicalFullName")]
    public string? PhysicalFullName { get; set; }

    [JsonPropertyName("sizeInMb")]
    public float? SizeInMb { get; set; }
}
