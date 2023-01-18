using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;


internal class X12ProtocolSettingsModel
{
    [JsonPropertyName("acknowledgementSettings")]
    [Required]
    public X12AcknowledgementSettingsModel AcknowledgementSettings { get; set; }

    [JsonPropertyName("envelopeOverrides")]
    public List<X12EnvelopeOverrideModel>? EnvelopeOverrides { get; set; }

    [JsonPropertyName("envelopeSettings")]
    [Required]
    public X12EnvelopeSettingsModel EnvelopeSettings { get; set; }

    [JsonPropertyName("framingSettings")]
    [Required]
    public X12FramingSettingsModel FramingSettings { get; set; }

    [JsonPropertyName("messageFilter")]
    [Required]
    public X12MessageFilterModel MessageFilter { get; set; }

    [JsonPropertyName("messageFilterList")]
    public List<X12MessageIdentifierModel>? MessageFilterList { get; set; }

    [JsonPropertyName("processingSettings")]
    [Required]
    public X12ProcessingSettingsModel ProcessingSettings { get; set; }

    [JsonPropertyName("schemaReferences")]
    [Required]
    public List<X12SchemaReferenceModel> SchemaReferences { get; set; }

    [JsonPropertyName("securitySettings")]
    [Required]
    public X12SecuritySettingsModel SecuritySettings { get; set; }

    [JsonPropertyName("validationOverrides")]
    public List<X12ValidationOverrideModel>? ValidationOverrides { get; set; }

    [JsonPropertyName("validationSettings")]
    [Required]
    public X12ValidationSettingsModel ValidationSettings { get; set; }

    [JsonPropertyName("x12DelimiterOverrides")]
    public List<X12DelimiterOverridesModel>? X12DelimiterOverrides { get; set; }
}
