using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;


internal class EdifactProcessingSettingsModel
{
    [JsonPropertyName("createEmptyXmlTagsForTrailingSeparators")]
    [Required]
    public bool CreateEmptyXmlTagsForTrailingSeparators { get; set; }

    [JsonPropertyName("maskSecurityInfo")]
    [Required]
    public bool MaskSecurityInfo { get; set; }

    [JsonPropertyName("preserveInterchange")]
    [Required]
    public bool PreserveInterchange { get; set; }

    [JsonPropertyName("suspendInterchangeOnError")]
    [Required]
    public bool SuspendInterchangeOnError { get; set; }

    [JsonPropertyName("useDotAsDecimalSeparator")]
    [Required]
    public bool UseDotAsDecimalSeparator { get; set; }
}
