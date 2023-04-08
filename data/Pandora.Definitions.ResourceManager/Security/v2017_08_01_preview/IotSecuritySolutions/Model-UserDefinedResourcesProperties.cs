using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2017_08_01_preview.IotSecuritySolutions;


internal class UserDefinedResourcesPropertiesModel
{
    [JsonPropertyName("query")]
    [Required]
    public string Query { get; set; }

    [JsonPropertyName("querySubscriptions")]
    [Required]
    public List<string> QuerySubscriptions { get; set; }
}
