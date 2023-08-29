using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ResourceGraph.v2022_10_01.Resources;

[ValueForType("FacetError")]
internal class FacetErrorModel : FacetModel
{
    [JsonPropertyName("errors")]
    [Required]
    public List<ErrorDetailsModel> Errors { get; set; }
}
