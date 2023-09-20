// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ChangeNotificationEncryptedContentModel
{
    [JsonPropertyName("data")]
    public string? Data { get; set; }

    [JsonPropertyName("dataKey")]
    public string? DataKey { get; set; }

    [JsonPropertyName("dataSignature")]
    public string? DataSignature { get; set; }

    [JsonPropertyName("encryptionCertificateId")]
    public string? EncryptionCertificateId { get; set; }

    [JsonPropertyName("encryptionCertificateThumbprint")]
    public string? EncryptionCertificateThumbprint { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
