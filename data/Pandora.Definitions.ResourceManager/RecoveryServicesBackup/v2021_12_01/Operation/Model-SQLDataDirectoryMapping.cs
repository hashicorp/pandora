using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2021_12_01.Operation;


internal class SQLDataDirectoryMappingModel
{
    [JsonPropertyName("mappingType")]
    public SQLDataDirectoryTypeConstant? MappingType { get; set; }

    [JsonPropertyName("sourceLogicalName")]
    public string? SourceLogicalName { get; set; }

    [JsonPropertyName("sourcePath")]
    public string? SourcePath { get; set; }

    [JsonPropertyName("targetPath")]
    public string? TargetPath { get; set; }
}
