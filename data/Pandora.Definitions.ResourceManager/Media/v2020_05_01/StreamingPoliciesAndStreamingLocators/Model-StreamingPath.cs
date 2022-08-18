using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.StreamingPoliciesAndStreamingLocators;


internal class StreamingPathModel
{
    [JsonPropertyName("encryptionScheme")]
    [Required]
    public EncryptionSchemeConstant EncryptionScheme { get; set; }

    [JsonPropertyName("paths")]
    public List<string>? Paths { get; set; }

    [JsonPropertyName("streamingProtocol")]
    [Required]
    public StreamingPolicyStreamingProtocolConstant StreamingProtocol { get; set; }
}
