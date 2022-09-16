using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.CommunityGalleryImages;


internal class CommunityGalleryImagePropertiesModel
{
    [JsonPropertyName("disallowed")]
    public DisallowedModel? Disallowed { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endOfLifeDate")]
    public DateTime? EndOfLifeDate { get; set; }

    [JsonPropertyName("features")]
    public List<GalleryImageFeatureModel>? Features { get; set; }

    [JsonPropertyName("hyperVGeneration")]
    public HyperVGenerationConstant? HyperVGeneration { get; set; }

    [JsonPropertyName("identifier")]
    [Required]
    public GalleryImageIdentifierModel Identifier { get; set; }

    [JsonPropertyName("osState")]
    [Required]
    public OperatingSystemStateTypesConstant OsState { get; set; }

    [JsonPropertyName("osType")]
    [Required]
    public OperatingSystemTypesConstant OsType { get; set; }

    [JsonPropertyName("purchasePlan")]
    public ImagePurchasePlanModel? PurchasePlan { get; set; }

    [JsonPropertyName("recommended")]
    public RecommendedMachineConfigurationModel? Recommended { get; set; }
}
