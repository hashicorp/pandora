// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

namespace Pandora.Definitions.MicrosoftGraph.Beta.RoleManagement.Beta.RoleManagementEnterpriseAppResourceNamespace;

internal class CreateRoleManagementEnterpriseAppByIdResourceNamespaceByIdImportResourceActionRequestModel
{
    [JsonPropertyName("format")]
    public string? Format { get; set; }

    [JsonPropertyName("overwriteResourceNamespace")]
    public bool? OverwriteResourceNamespace { get; set; }

    [JsonPropertyName("value")]
    public string? Value { get; set; }
}
