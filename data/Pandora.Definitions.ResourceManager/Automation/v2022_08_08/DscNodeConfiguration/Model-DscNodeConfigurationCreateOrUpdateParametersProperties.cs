using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2022_08_08.DscNodeConfiguration;


internal class DscNodeConfigurationCreateOrUpdateParametersPropertiesModel
{
    [JsonPropertyName("configuration")]
    [Required]
    public DscConfigurationAssociationPropertyModel Configuration { get; set; }

    [JsonPropertyName("incrementNodeConfigurationBuild")]
    public bool? IncrementNodeConfigurationBuild { get; set; }

    [JsonPropertyName("source")]
    [Required]
    public ContentSourceModel Source { get; set; }
}
