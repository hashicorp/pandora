using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.ChangeDataCapture;


internal class ChangeDataCaptureModel
{
    [JsonPropertyName("allowVNetOverride")]
    public bool? AllowVNetOverride { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("folder")]
    public ChangeDataCaptureFolderModel? Folder { get; set; }

    [JsonPropertyName("policy")]
    [Required]
    public MapperPolicyModel Policy { get; set; }

    [JsonPropertyName("sourceConnectionsInfo")]
    [Required]
    public List<MapperSourceConnectionsInfoModel> SourceConnectionsInfo { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("targetConnectionsInfo")]
    [Required]
    public List<MapperTargetConnectionsInfoModel> TargetConnectionsInfo { get; set; }
}
