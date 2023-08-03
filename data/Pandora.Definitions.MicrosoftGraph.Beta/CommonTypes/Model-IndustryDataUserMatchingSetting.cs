// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class IndustryDataUserMatchingSettingModel
{
    [JsonPropertyName("matchTarget")]
    public UserMatchTargetReferenceValueModel? MatchTarget { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("priorityOrder")]
    public int? PriorityOrder { get; set; }

    [JsonPropertyName("roleGroup")]
    public RoleGroupModel? RoleGroup { get; set; }

    [JsonPropertyName("sourceIdentifier")]
    public IdentifierTypeReferenceValueModel? SourceIdentifier { get; set; }
}
