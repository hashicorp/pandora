using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.SecuritySolutionsReferenceData;


internal class SecuritySolutionsReferenceDataPropertiesModel
{
    [JsonPropertyName("alertVendorName")]
    [Required]
    public string AlertVendorName { get; set; }

    [JsonPropertyName("packageInfoUrl")]
    [Required]
    public string PackageInfoUrl { get; set; }

    [JsonPropertyName("productName")]
    [Required]
    public string ProductName { get; set; }

    [JsonPropertyName("publisher")]
    [Required]
    public string Publisher { get; set; }

    [JsonPropertyName("publisherDisplayName")]
    [Required]
    public string PublisherDisplayName { get; set; }

    [JsonPropertyName("securityFamily")]
    [Required]
    public SecurityFamilyConstant SecurityFamily { get; set; }

    [JsonPropertyName("template")]
    [Required]
    public string Template { get; set; }
}
