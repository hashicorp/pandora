using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.ManagedInstanceEncryptionProtectors;


internal class ManagedInstanceEncryptionProtectorPropertiesModel
{
    [JsonPropertyName("autoRotationEnabled")]
    public bool? AutoRotationEnabled { get; set; }

    [JsonPropertyName("serverKeyName")]
    public string? ServerKeyName { get; set; }

    [JsonPropertyName("serverKeyType")]
    [Required]
    public ServerKeyTypeConstant ServerKeyType { get; set; }

    [JsonPropertyName("thumbprint")]
    public string? Thumbprint { get; set; }

    [JsonPropertyName("uri")]
    public string? Uri { get; set; }
}
