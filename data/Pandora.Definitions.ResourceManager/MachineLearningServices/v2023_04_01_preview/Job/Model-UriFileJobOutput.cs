using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Job;

[ValueForType("uri_file")]
internal class UriFileJobOutputModel : JobOutputModel
{
    [JsonPropertyName("assetName")]
    public string? AssetName { get; set; }

    [JsonPropertyName("assetVersion")]
    public string? AssetVersion { get; set; }

    [JsonPropertyName("autoDeleteSetting")]
    public AutoDeleteSettingModel? AutoDeleteSetting { get; set; }

    [JsonPropertyName("mode")]
    public OutputDeliveryModeConstant? Mode { get; set; }

    [JsonPropertyName("uri")]
    public string? Uri { get; set; }
}
