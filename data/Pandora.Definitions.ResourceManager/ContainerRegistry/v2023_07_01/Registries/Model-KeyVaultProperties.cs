using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2023_07_01.Registries;


internal class KeyVaultPropertiesModel
{
    [JsonPropertyName("identity")]
    public string? Identity { get; set; }

    [JsonPropertyName("keyIdentifier")]
    public string? KeyIdentifier { get; set; }

    [JsonPropertyName("keyRotationEnabled")]
    public bool? KeyRotationEnabled { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastKeyRotationTimestamp")]
    public DateTime? LastKeyRotationTimestamp { get; set; }

    [JsonPropertyName("versionedKeyIdentifier")]
    public string? VersionedKeyIdentifier { get; set; }
}
