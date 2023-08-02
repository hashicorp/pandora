// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AuthenticationConditionsApplicationsModel
{
    [JsonPropertyName("includeAllApplications")]
    public bool? IncludeAllApplications { get; set; }

    [JsonPropertyName("includeApplications")]
    public List<AuthenticationConditionApplicationModel>? IncludeApplications { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
