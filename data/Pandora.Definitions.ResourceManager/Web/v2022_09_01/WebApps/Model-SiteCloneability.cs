using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;


internal class SiteCloneabilityModel
{
    [JsonPropertyName("blockingCharacteristics")]
    public List<SiteCloneabilityCriterionModel>? BlockingCharacteristics { get; set; }

    [JsonPropertyName("blockingFeatures")]
    public List<SiteCloneabilityCriterionModel>? BlockingFeatures { get; set; }

    [JsonPropertyName("result")]
    public CloneAbilityResultConstant? Result { get; set; }

    [JsonPropertyName("unsupportedFeatures")]
    public List<SiteCloneabilityCriterionModel>? UnsupportedFeatures { get; set; }
}
