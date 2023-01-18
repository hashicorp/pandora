using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;


internal class X12FramingSettingsModel
{
    [JsonPropertyName("characterSet")]
    [Required]
    public X12CharacterSetConstant CharacterSet { get; set; }

    [JsonPropertyName("componentSeparator")]
    [Required]
    public int ComponentSeparator { get; set; }

    [JsonPropertyName("dataElementSeparator")]
    [Required]
    public int DataElementSeparator { get; set; }

    [JsonPropertyName("replaceCharacter")]
    [Required]
    public int ReplaceCharacter { get; set; }

    [JsonPropertyName("replaceSeparatorsInPayload")]
    [Required]
    public bool ReplaceSeparatorsInPayload { get; set; }

    [JsonPropertyName("segmentTerminator")]
    [Required]
    public int SegmentTerminator { get; set; }

    [JsonPropertyName("segmentTerminatorSuffix")]
    [Required]
    public SegmentTerminatorSuffixConstant SegmentTerminatorSuffix { get; set; }
}
