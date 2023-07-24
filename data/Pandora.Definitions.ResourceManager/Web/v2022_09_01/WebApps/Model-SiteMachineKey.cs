using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;


internal class SiteMachineKeyModel
{
    [JsonPropertyName("decryption")]
    public string? Decryption { get; set; }

    [JsonPropertyName("decryptionKey")]
    public string? DecryptionKey { get; set; }

    [JsonPropertyName("validation")]
    public string? Validation { get; set; }

    [JsonPropertyName("validationKey")]
    public string? ValidationKey { get; set; }
}
