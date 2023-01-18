using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccounts;


internal class TrackingEventsDefinitionModel
{
    [JsonPropertyName("events")]
    [Required]
    public List<TrackingEventModel> Events { get; set; }

    [JsonPropertyName("sourceType")]
    [Required]
    public string SourceType { get; set; }

    [JsonPropertyName("trackEventsOptions")]
    public TrackEventsOperationOptionsConstant? TrackEventsOptions { get; set; }
}
