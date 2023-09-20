// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class FileEncryptionInfoModel
{
    [JsonPropertyName("encryptionKey")]
    public string? EncryptionKey { get; set; }

    [JsonPropertyName("fileDigest")]
    public string? FileDigest { get; set; }

    [JsonPropertyName("fileDigestAlgorithm")]
    public string? FileDigestAlgorithm { get; set; }

    [JsonPropertyName("initializationVector")]
    public string? InitializationVector { get; set; }

    [JsonPropertyName("mac")]
    public string? Mac { get; set; }

    [JsonPropertyName("macKey")]
    public string? MacKey { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("profileIdentifier")]
    public string? ProfileIdentifier { get; set; }
}
