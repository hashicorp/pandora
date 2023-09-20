// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ConditionalAccessClientApplicationsModel
{
    [JsonPropertyName("excludeServicePrincipals")]
    public List<string>? ExcludeServicePrincipals { get; set; }

    [JsonPropertyName("includeServicePrincipals")]
    public List<string>? IncludeServicePrincipals { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("servicePrincipalFilter")]
    public ConditionalAccessFilterModel? ServicePrincipalFilter { get; set; }
}
