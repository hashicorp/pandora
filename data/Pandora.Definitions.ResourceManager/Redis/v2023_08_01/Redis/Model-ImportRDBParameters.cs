using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Redis.v2023_08_01.Redis;


internal class ImportRDBParametersModel
{
    [JsonPropertyName("files")]
    [Required]
    public List<string> Files { get; set; }

    [JsonPropertyName("format")]
    public string? Format { get; set; }

    [JsonPropertyName("preferred-data-archive-auth-method")]
    public string? PreferredDataArchiveAuthMethod { get; set; }

    [JsonPropertyName("storage-subscription-id")]
    public string? StorageSubscriptionId { get; set; }
}
