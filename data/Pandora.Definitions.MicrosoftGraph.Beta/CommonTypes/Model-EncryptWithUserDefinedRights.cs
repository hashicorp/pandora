// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class EncryptWithUserDefinedRightsModel
{
    [JsonPropertyName("allowAdHocPermissions")]
    public bool? AllowAdHocPermissions { get; set; }

    [JsonPropertyName("allowMailForwarding")]
    public bool? AllowMailForwarding { get; set; }

    [JsonPropertyName("decryptionRightsManagementTemplateId")]
    public string? DecryptionRightsManagementTemplateId { get; set; }

    [JsonPropertyName("encryptWith")]
    public EncryptWithUserDefinedRightsEncryptWithConstant? EncryptWith { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
