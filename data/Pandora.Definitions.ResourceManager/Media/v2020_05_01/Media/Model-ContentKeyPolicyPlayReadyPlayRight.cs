using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.Media;


internal class ContentKeyPolicyPlayReadyPlayRightModel
{
    [JsonPropertyName("agcAndColorStripeRestriction")]
    public int? AgcAndColorStripeRestriction { get; set; }

    [JsonPropertyName("allowPassingVideoContentToUnknownOutput")]
    [Required]
    public ContentKeyPolicyPlayReadyUnknownOutputPassingOptionConstant AllowPassingVideoContentToUnknownOutput { get; set; }

    [JsonPropertyName("analogVideoOpl")]
    public int? AnalogVideoOpl { get; set; }

    [JsonPropertyName("compressedDigitalAudioOpl")]
    public int? CompressedDigitalAudioOpl { get; set; }

    [JsonPropertyName("compressedDigitalVideoOpl")]
    public int? CompressedDigitalVideoOpl { get; set; }

    [JsonPropertyName("digitalVideoOnlyContentRestriction")]
    [Required]
    public bool DigitalVideoOnlyContentRestriction { get; set; }

    [JsonPropertyName("explicitAnalogTelevisionOutputRestriction")]
    public ContentKeyPolicyPlayReadyExplicitAnalogTelevisionRestrictionModel? ExplicitAnalogTelevisionOutputRestriction { get; set; }

    [JsonPropertyName("firstPlayExpiration")]
    public string? FirstPlayExpiration { get; set; }

    [JsonPropertyName("imageConstraintForAnalogComponentVideoRestriction")]
    [Required]
    public bool ImageConstraintForAnalogComponentVideoRestriction { get; set; }

    [JsonPropertyName("imageConstraintForAnalogComputerMonitorRestriction")]
    [Required]
    public bool ImageConstraintForAnalogComputerMonitorRestriction { get; set; }

    [JsonPropertyName("scmsRestriction")]
    public int? ScmsRestriction { get; set; }

    [JsonPropertyName("uncompressedDigitalAudioOpl")]
    public int? UncompressedDigitalAudioOpl { get; set; }

    [JsonPropertyName("uncompressedDigitalVideoOpl")]
    public int? UncompressedDigitalVideoOpl { get; set; }
}
