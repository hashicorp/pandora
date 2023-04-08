using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.ApplicationWhitelistings;


internal class PublisherInfoModel
{
    [JsonPropertyName("binaryName")]
    public string? BinaryName { get; set; }

    [JsonPropertyName("productName")]
    public string? ProductName { get; set; }

    [JsonPropertyName("publisherName")]
    public string? PublisherName { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
