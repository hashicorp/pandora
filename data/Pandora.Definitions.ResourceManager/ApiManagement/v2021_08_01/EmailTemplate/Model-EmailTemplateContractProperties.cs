using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.EmailTemplate;


internal class EmailTemplateContractPropertiesModel
{
    [JsonPropertyName("body")]
    [Required]
    public string Body { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("isDefault")]
    public bool? IsDefault { get; set; }

    [JsonPropertyName("parameters")]
    public List<EmailTemplateParametersContractPropertiesModel>? Parameters { get; set; }

    [JsonPropertyName("subject")]
    [Required]
    public string Subject { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }
}
