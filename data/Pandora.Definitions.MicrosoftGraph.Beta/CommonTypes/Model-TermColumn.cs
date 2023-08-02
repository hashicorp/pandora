// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class TermColumnModel
{
    [JsonPropertyName("allowMultipleValues")]
    public bool? AllowMultipleValues { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("parentTerm")]
    public TermModel? ParentTerm { get; set; }

    [JsonPropertyName("showFullyQualifiedName")]
    public bool? ShowFullyQualifiedName { get; set; }

    [JsonPropertyName("termSet")]
    public SetModel? TermSet { get; set; }
}
