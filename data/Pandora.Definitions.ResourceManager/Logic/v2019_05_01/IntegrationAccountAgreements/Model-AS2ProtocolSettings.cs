using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;


internal class AS2ProtocolSettingsModel
{
    [JsonPropertyName("acknowledgementConnectionSettings")]
    [Required]
    public AS2AcknowledgementConnectionSettingsModel AcknowledgementConnectionSettings { get; set; }

    [JsonPropertyName("envelopeSettings")]
    [Required]
    public AS2EnvelopeSettingsModel EnvelopeSettings { get; set; }

    [JsonPropertyName("errorSettings")]
    [Required]
    public AS2ErrorSettingsModel ErrorSettings { get; set; }

    [JsonPropertyName("mdnSettings")]
    [Required]
    public AS2MdnSettingsModel MdnSettings { get; set; }

    [JsonPropertyName("messageConnectionSettings")]
    [Required]
    public AS2MessageConnectionSettingsModel MessageConnectionSettings { get; set; }

    [JsonPropertyName("securitySettings")]
    [Required]
    public AS2SecuritySettingsModel SecuritySettings { get; set; }

    [JsonPropertyName("validationSettings")]
    [Required]
    public AS2ValidationSettingsModel ValidationSettings { get; set; }
}
