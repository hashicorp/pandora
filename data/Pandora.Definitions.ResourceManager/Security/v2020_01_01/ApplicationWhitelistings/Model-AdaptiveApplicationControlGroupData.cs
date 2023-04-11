using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.ApplicationWhitelistings;


internal class AdaptiveApplicationControlGroupDataModel
{
    [JsonPropertyName("configurationStatus")]
    public ConfigurationStatusConstant? ConfigurationStatus { get; set; }

    [JsonPropertyName("enforcementMode")]
    public EnforcementModeConstant? EnforcementMode { get; set; }

    [JsonPropertyName("issues")]
    public List<AdaptiveApplicationControlIssueSummaryModel>? Issues { get; set; }

    [JsonPropertyName("pathRecommendations")]
    public List<PathRecommendationModel>? PathRecommendations { get; set; }

    [JsonPropertyName("protectionMode")]
    public ProtectionModeModel? ProtectionMode { get; set; }

    [JsonPropertyName("recommendationStatus")]
    public RecommendationStatusConstant? RecommendationStatus { get; set; }

    [JsonPropertyName("sourceSystem")]
    public SourceSystemConstant? SourceSystem { get; set; }

    [JsonPropertyName("vmRecommendations")]
    public List<VMRecommendationModel>? VMRecommendations { get; set; }
}
