using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.DataConnectors;


internal class CodelessConnectorPollingConfigPropertiesModel
{
    [JsonPropertyName("auth")]
    [Required]
    public CodelessConnectorPollingAuthPropertiesModel Auth { get; set; }

    [JsonPropertyName("isActive")]
    public bool? IsActive { get; set; }

    [JsonPropertyName("paging")]
    public CodelessConnectorPollingPagingPropertiesModel? Paging { get; set; }

    [JsonPropertyName("request")]
    [Required]
    public CodelessConnectorPollingRequestPropertiesModel Request { get; set; }

    [JsonPropertyName("response")]
    public CodelessConnectorPollingResponsePropertiesModel? Response { get; set; }
}
