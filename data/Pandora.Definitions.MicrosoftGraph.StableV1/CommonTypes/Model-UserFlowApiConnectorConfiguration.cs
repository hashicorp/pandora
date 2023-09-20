// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class UserFlowApiConnectorConfigurationModel
{
    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("postAttributeCollection")]
    public IdentityApiConnectorModel? PostAttributeCollection { get; set; }

    [JsonPropertyName("postFederationSignup")]
    public IdentityApiConnectorModel? PostFederationSignup { get; set; }
}
