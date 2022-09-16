using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.WorkspaceManagedSqlServerServerEncryptionProtector;


internal class EncryptionProtectorPropertiesModel
{
    [JsonPropertyName("serverKeyName")]
    public string? ServerKeyName { get; set; }

    [JsonPropertyName("serverKeyType")]
    [Required]
    public ServerKeyTypeConstant ServerKeyType { get; set; }

    [JsonPropertyName("subregion")]
    public string? Subregion { get; set; }

    [JsonPropertyName("thumbprint")]
    public string? Thumbprint { get; set; }

    [JsonPropertyName("uri")]
    public string? Uri { get; set; }
}
