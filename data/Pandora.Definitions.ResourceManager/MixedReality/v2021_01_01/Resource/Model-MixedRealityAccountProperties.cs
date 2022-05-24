using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MixedReality.v2021_01_01.Resource;


internal class MixedRealityAccountPropertiesModel
{
    [JsonPropertyName("accountDomain")]
    public string? AccountDomain { get; set; }

    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    [JsonPropertyName("storageAccountName")]
    public string? StorageAccountName { get; set; }
}
