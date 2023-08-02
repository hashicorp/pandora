// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Applications.StableV1.Application;

internal class GetApplicationByIdsRequestModel
{
    [JsonPropertyName("ids")]
    public List<string>? Ids { get; set; }

    [JsonPropertyName("types")]
    public List<string>? Types { get; set; }
}
