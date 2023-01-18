using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;


internal class X12ValidationOverrideModel
{
    [JsonPropertyName("allowLeadingAndTrailingSpacesAndZeroes")]
    [Required]
    public bool AllowLeadingAndTrailingSpacesAndZeroes { get; set; }

    [JsonPropertyName("messageId")]
    [Required]
    public string MessageId { get; set; }

    [JsonPropertyName("trailingSeparatorPolicy")]
    [Required]
    public TrailingSeparatorPolicyConstant TrailingSeparatorPolicy { get; set; }

    [JsonPropertyName("trimLeadingAndTrailingSpacesAndZeroes")]
    [Required]
    public bool TrimLeadingAndTrailingSpacesAndZeroes { get; set; }

    [JsonPropertyName("validateCharacterSet")]
    [Required]
    public bool ValidateCharacterSet { get; set; }

    [JsonPropertyName("validateEDITypes")]
    [Required]
    public bool ValidateEDITypes { get; set; }

    [JsonPropertyName("validateXSDTypes")]
    [Required]
    public bool ValidateXSDTypes { get; set; }
}
