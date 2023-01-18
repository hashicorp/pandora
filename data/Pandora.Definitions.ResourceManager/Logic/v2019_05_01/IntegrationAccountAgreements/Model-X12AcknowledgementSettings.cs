using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;


internal class X12AcknowledgementSettingsModel
{
    [JsonPropertyName("acknowledgementControlNumberLowerBound")]
    [Required]
    public int AcknowledgementControlNumberLowerBound { get; set; }

    [JsonPropertyName("acknowledgementControlNumberPrefix")]
    public string? AcknowledgementControlNumberPrefix { get; set; }

    [JsonPropertyName("acknowledgementControlNumberSuffix")]
    public string? AcknowledgementControlNumberSuffix { get; set; }

    [JsonPropertyName("acknowledgementControlNumberUpperBound")]
    [Required]
    public int AcknowledgementControlNumberUpperBound { get; set; }

    [JsonPropertyName("batchFunctionalAcknowledgements")]
    [Required]
    public bool BatchFunctionalAcknowledgements { get; set; }

    [JsonPropertyName("batchImplementationAcknowledgements")]
    [Required]
    public bool BatchImplementationAcknowledgements { get; set; }

    [JsonPropertyName("batchTechnicalAcknowledgements")]
    [Required]
    public bool BatchTechnicalAcknowledgements { get; set; }

    [JsonPropertyName("functionalAcknowledgementVersion")]
    public string? FunctionalAcknowledgementVersion { get; set; }

    [JsonPropertyName("implementationAcknowledgementVersion")]
    public string? ImplementationAcknowledgementVersion { get; set; }

    [JsonPropertyName("needFunctionalAcknowledgement")]
    [Required]
    public bool NeedFunctionalAcknowledgement { get; set; }

    [JsonPropertyName("needImplementationAcknowledgement")]
    [Required]
    public bool NeedImplementationAcknowledgement { get; set; }

    [JsonPropertyName("needLoopForValidMessages")]
    [Required]
    public bool NeedLoopForValidMessages { get; set; }

    [JsonPropertyName("needTechnicalAcknowledgement")]
    [Required]
    public bool NeedTechnicalAcknowledgement { get; set; }

    [JsonPropertyName("rolloverAcknowledgementControlNumber")]
    [Required]
    public bool RolloverAcknowledgementControlNumber { get; set; }

    [JsonPropertyName("sendSynchronousAcknowledgement")]
    [Required]
    public bool SendSynchronousAcknowledgement { get; set; }
}
