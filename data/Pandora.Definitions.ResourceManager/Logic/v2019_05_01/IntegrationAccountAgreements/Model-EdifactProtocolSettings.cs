using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;


internal class EdifactProtocolSettingsModel
{
    [JsonPropertyName("acknowledgementSettings")]
    [Required]
    public EdifactAcknowledgementSettingsModel AcknowledgementSettings { get; set; }

    [JsonPropertyName("edifactDelimiterOverrides")]
    public List<EdifactDelimiterOverrideModel>? EdifactDelimiterOverrides { get; set; }

    [JsonPropertyName("envelopeOverrides")]
    public List<EdifactEnvelopeOverrideModel>? EnvelopeOverrides { get; set; }

    [JsonPropertyName("envelopeSettings")]
    [Required]
    public EdifactEnvelopeSettingsModel EnvelopeSettings { get; set; }

    [JsonPropertyName("framingSettings")]
    [Required]
    public EdifactFramingSettingsModel FramingSettings { get; set; }

    [JsonPropertyName("messageFilter")]
    [Required]
    public EdifactMessageFilterModel MessageFilter { get; set; }

    [JsonPropertyName("messageFilterList")]
    public List<EdifactMessageIdentifierModel>? MessageFilterList { get; set; }

    [JsonPropertyName("processingSettings")]
    [Required]
    public EdifactProcessingSettingsModel ProcessingSettings { get; set; }

    [JsonPropertyName("schemaReferences")]
    [Required]
    public List<EdifactSchemaReferenceModel> SchemaReferences { get; set; }

    [JsonPropertyName("validationOverrides")]
    public List<EdifactValidationOverrideModel>? ValidationOverrides { get; set; }

    [JsonPropertyName("validationSettings")]
    [Required]
    public EdifactValidationSettingsModel ValidationSettings { get; set; }
}
