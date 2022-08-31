using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.FileService;


internal class FileServicePropertiesPropertiesModel
{
    [JsonPropertyName("cors")]
    public CorsRulesModel? Cors { get; set; }

    [JsonPropertyName("protocolSettings")]
    public ProtocolSettingsModel? ProtocolSettings { get; set; }

    [JsonPropertyName("shareDeleteRetentionPolicy")]
    public DeleteRetentionPolicyModel? ShareDeleteRetentionPolicy { get; set; }
}
