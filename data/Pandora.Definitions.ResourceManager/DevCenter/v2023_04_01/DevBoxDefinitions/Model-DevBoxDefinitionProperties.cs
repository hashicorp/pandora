using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevCenter.v2023_04_01.DevBoxDefinitions;


internal class DevBoxDefinitionPropertiesModel
{
    [JsonPropertyName("activeImageReference")]
    public ImageReferenceModel? ActiveImageReference { get; set; }

    [JsonPropertyName("hibernateSupport")]
    public HibernateSupportConstant? HibernateSupport { get; set; }

    [JsonPropertyName("imageReference")]
    [Required]
    public ImageReferenceModel ImageReference { get; set; }

    [JsonPropertyName("imageValidationErrorDetails")]
    public ImageValidationErrorDetailsModel? ImageValidationErrorDetails { get; set; }

    [JsonPropertyName("imageValidationStatus")]
    public ImageValidationStatusConstant? ImageValidationStatus { get; set; }

    [JsonPropertyName("osStorageType")]
    public string? OsStorageType { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("sku")]
    [Required]
    public SkuModel Sku { get; set; }
}
