// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Applications.Beta.Application;

internal class RemoveApplicationKeyRequestModel
{
    [JsonPropertyName("keyId")]
    public string? KeyId { get; set; }

    [JsonPropertyName("proof")]
    public string? Proof { get; set; }
}
