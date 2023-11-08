using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2023_11_01.Databases;


internal class LinkedDatabaseModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("state")]
    public LinkStateConstant? State { get; set; }
}
