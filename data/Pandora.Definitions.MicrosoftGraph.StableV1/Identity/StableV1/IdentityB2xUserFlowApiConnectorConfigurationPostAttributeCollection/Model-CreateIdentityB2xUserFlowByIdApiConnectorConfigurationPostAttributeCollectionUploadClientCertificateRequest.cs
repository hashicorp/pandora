// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Identity.StableV1.IdentityB2xUserFlowApiConnectorConfigurationPostAttributeCollection;

internal class CreateIdentityB2xUserFlowByIdApiConnectorConfigurationPostAttributeCollectionUploadClientCertificateRequestModel
{
    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("pkcs12Value")]
    public string? Pkcs12Value { get; set; }
}
