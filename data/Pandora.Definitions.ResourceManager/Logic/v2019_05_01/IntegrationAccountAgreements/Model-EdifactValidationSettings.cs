using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;


internal class EdifactValidationSettingsModel
{
    [JsonPropertyName("allowLeadingAndTrailingSpacesAndZeroes")]
    [Required]
    public bool AllowLeadingAndTrailingSpacesAndZeroes { get; set; }

    [JsonPropertyName("checkDuplicateGroupControlNumber")]
    [Required]
    public bool CheckDuplicateGroupControlNumber { get; set; }

    [JsonPropertyName("checkDuplicateInterchangeControlNumber")]
    [Required]
    public bool CheckDuplicateInterchangeControlNumber { get; set; }

    [JsonPropertyName("checkDuplicateTransactionSetControlNumber")]
    [Required]
    public bool CheckDuplicateTransactionSetControlNumber { get; set; }

    [JsonPropertyName("interchangeControlNumberValidityDays")]
    [Required]
    public int InterchangeControlNumberValidityDays { get; set; }

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
