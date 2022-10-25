using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CustomProviders.v2018_09_01_preview.CustomResourceProvider;


internal class CustomRPValidationsModel
{
    [JsonPropertyName("specification")]
    [Required]
    public string Specification { get; set; }

    [JsonPropertyName("validationType")]
    public ValidationTypeConstant? ValidationType { get; set; }
}
