using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.ManagedAPIs;


internal class WsdlServiceModel
{
    [JsonPropertyName("endpointQualifiedNames")]
    public List<string>? EndpointQualifiedNames { get; set; }

    [JsonPropertyName("qualifiedName")]
    [Required]
    public string QualifiedName { get; set; }
}
