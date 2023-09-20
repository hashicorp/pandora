// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AccessPackageAnswerChoiceModel
{
    [JsonPropertyName("actualValue")]
    public string? ActualValue { get; set; }

    [JsonPropertyName("displayValue")]
    public AccessPackageLocalizedContentModel? DisplayValue { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
