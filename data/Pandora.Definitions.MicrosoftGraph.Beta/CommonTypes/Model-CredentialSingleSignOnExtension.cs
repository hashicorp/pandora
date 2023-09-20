// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CredentialSingleSignOnExtensionModel
{
    [JsonPropertyName("configurations")]
    public List<KeyTypedValuePairModel>? Configurations { get; set; }

    [JsonPropertyName("domains")]
    public List<string>? Domains { get; set; }

    [JsonPropertyName("extensionIdentifier")]
    public string? ExtensionIdentifier { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("realm")]
    public string? Realm { get; set; }

    [JsonPropertyName("teamIdentifier")]
    public string? TeamIdentifier { get; set; }
}
