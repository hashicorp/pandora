using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2022_01_01.Databases;


internal class PersistenceModel
{
    [JsonPropertyName("aofEnabled")]
    public bool? AofEnabled { get; set; }

    [JsonPropertyName("aofFrequency")]
    public AofFrequencyConstant? AofFrequency { get; set; }

    [JsonPropertyName("rdbEnabled")]
    public bool? RdbEnabled { get; set; }

    [JsonPropertyName("rdbFrequency")]
    public RdbFrequencyConstant? RdbFrequency { get; set; }
}
