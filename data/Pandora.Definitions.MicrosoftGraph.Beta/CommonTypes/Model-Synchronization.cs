// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SynchronizationModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("jobs")]
    public List<SynchronizationJobModel>? Jobs { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("secrets")]
    public List<SynchronizationSecretKeyStringValuePairModel>? Secrets { get; set; }

    [JsonPropertyName("templates")]
    public List<SynchronizationTemplateModel>? Templates { get; set; }
}
