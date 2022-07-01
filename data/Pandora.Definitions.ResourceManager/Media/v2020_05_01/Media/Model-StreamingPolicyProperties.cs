using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.Media;


internal class StreamingPolicyPropertiesModel
{
    [JsonPropertyName("commonEncryptionCbcs")]
    public CommonEncryptionCbcsModel? CommonEncryptionCbcs { get; set; }

    [JsonPropertyName("commonEncryptionCenc")]
    public CommonEncryptionCencModel? CommonEncryptionCenc { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("created")]
    public DateTime? Created { get; set; }

    [JsonPropertyName("defaultContentKeyPolicyName")]
    public string? DefaultContentKeyPolicyName { get; set; }

    [JsonPropertyName("envelopeEncryption")]
    public EnvelopeEncryptionModel? EnvelopeEncryption { get; set; }

    [JsonPropertyName("noEncryption")]
    public NoEncryptionModel? NoEncryption { get; set; }
}
