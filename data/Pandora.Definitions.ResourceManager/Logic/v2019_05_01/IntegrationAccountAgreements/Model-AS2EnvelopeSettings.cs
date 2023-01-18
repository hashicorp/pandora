using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;


internal class AS2EnvelopeSettingsModel
{
    [JsonPropertyName("autogenerateFileName")]
    [Required]
    public bool AutogenerateFileName { get; set; }

    [JsonPropertyName("fileNameTemplate")]
    [Required]
    public string FileNameTemplate { get; set; }

    [JsonPropertyName("messageContentType")]
    [Required]
    public string MessageContentType { get; set; }

    [JsonPropertyName("suspendMessageOnFileNameGenerationError")]
    [Required]
    public bool SuspendMessageOnFileNameGenerationError { get; set; }

    [JsonPropertyName("transmitFileNameInMimeHeader")]
    [Required]
    public bool TransmitFileNameInMimeHeader { get; set; }
}
