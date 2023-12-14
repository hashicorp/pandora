using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2023_09_01.PostRules;


internal class CategoryModel
{
    [JsonPropertyName("feeds")]
    [Required]
    public List<string> Feeds { get; set; }

    [JsonPropertyName("urlCustom")]
    [Required]
    public List<string> UrlCustom { get; set; }
}
