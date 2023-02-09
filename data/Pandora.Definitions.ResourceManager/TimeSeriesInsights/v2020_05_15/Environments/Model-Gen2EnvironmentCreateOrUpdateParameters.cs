using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.TimeSeriesInsights.v2020_05_15.Environments;

[ValueForType("Gen2")]
internal class Gen2EnvironmentCreateOrUpdateParametersModel : EnvironmentCreateOrUpdateParametersModel
{
    [JsonPropertyName("properties")]
    [Required]
    public Gen2EnvironmentCreationPropertiesModel Properties { get; set; }
}
