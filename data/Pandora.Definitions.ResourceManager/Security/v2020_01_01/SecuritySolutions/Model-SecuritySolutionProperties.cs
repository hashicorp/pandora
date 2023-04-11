using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.SecuritySolutions;


internal class SecuritySolutionPropertiesModel
{
    [JsonPropertyName("protectionStatus")]
    [Required]
    public string ProtectionStatus { get; set; }

    [JsonPropertyName("provisioningState")]
    [Required]
    public ProvisioningStateConstant ProvisioningState { get; set; }

    [JsonPropertyName("securityFamily")]
    [Required]
    public SecurityFamilyConstant SecurityFamily { get; set; }

    [JsonPropertyName("template")]
    [Required]
    public string Template { get; set; }
}
