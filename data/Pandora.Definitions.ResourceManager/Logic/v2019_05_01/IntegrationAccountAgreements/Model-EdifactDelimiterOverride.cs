using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;


internal class EdifactDelimiterOverrideModel
{
    [JsonPropertyName("componentSeparator")]
    [Required]
    public int ComponentSeparator { get; set; }

    [JsonPropertyName("dataElementSeparator")]
    [Required]
    public int DataElementSeparator { get; set; }

    [JsonPropertyName("decimalPointIndicator")]
    [Required]
    public EdifactDecimalIndicatorConstant DecimalPointIndicator { get; set; }

    [JsonPropertyName("messageAssociationAssignedCode")]
    public string? MessageAssociationAssignedCode { get; set; }

    [JsonPropertyName("messageId")]
    public string? MessageId { get; set; }

    [JsonPropertyName("messageRelease")]
    public string? MessageRelease { get; set; }

    [JsonPropertyName("messageVersion")]
    public string? MessageVersion { get; set; }

    [JsonPropertyName("releaseIndicator")]
    [Required]
    public int ReleaseIndicator { get; set; }

    [JsonPropertyName("repetitionSeparator")]
    [Required]
    public int RepetitionSeparator { get; set; }

    [JsonPropertyName("segmentTerminator")]
    [Required]
    public int SegmentTerminator { get; set; }

    [JsonPropertyName("segmentTerminatorSuffix")]
    [Required]
    public SegmentTerminatorSuffixConstant SegmentTerminatorSuffix { get; set; }

    [JsonPropertyName("targetNamespace")]
    public string? TargetNamespace { get; set; }
}
