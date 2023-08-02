// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class OemWarrantyModel
{
    [JsonPropertyName("additionalWarranties")]
    public List<WarrantyOfferModel>? AdditionalWarranties { get; set; }

    [JsonPropertyName("baseWarranties")]
    public List<WarrantyOfferModel>? BaseWarranties { get; set; }

    [JsonPropertyName("deviceConfigurationUrl")]
    public string? DeviceConfigurationUrl { get; set; }

    [JsonPropertyName("deviceWarrantyUrl")]
    public string? DeviceWarrantyUrl { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
