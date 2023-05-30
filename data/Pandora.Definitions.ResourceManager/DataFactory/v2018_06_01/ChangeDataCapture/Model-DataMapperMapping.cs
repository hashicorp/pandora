using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.ChangeDataCapture;


internal class DataMapperMappingModel
{
    [JsonPropertyName("attributeMappingInfo")]
    public MapperAttributeMappingsModel? AttributeMappingInfo { get; set; }

    [JsonPropertyName("sourceConnectionReference")]
    public MapperConnectionReferenceModel? SourceConnectionReference { get; set; }

    [JsonPropertyName("sourceDenormalizeInfo")]
    public object? SourceDenormalizeInfo { get; set; }

    [JsonPropertyName("sourceEntityName")]
    public string? SourceEntityName { get; set; }

    [JsonPropertyName("targetEntityName")]
    public string? TargetEntityName { get; set; }
}
