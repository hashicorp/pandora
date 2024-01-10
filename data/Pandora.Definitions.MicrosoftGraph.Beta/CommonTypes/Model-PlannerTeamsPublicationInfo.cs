// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PlannerTeamsPublicationInfoModel
{
    [JsonPropertyName("creationSourceKind")]
    public PlannerTeamsPublicationInfoCreationSourceKindConstant? CreationSourceKind { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("publicationId")]
    public string? PublicationId { get; set; }

    [JsonPropertyName("publishedToPlanId")]
    public string? PublishedToPlanId { get; set; }

    [JsonPropertyName("publishingTeamId")]
    public string? PublishingTeamId { get; set; }

    [JsonPropertyName("publishingTeamName")]
    public string? PublishingTeamName { get; set; }

    [JsonPropertyName("teamsPublicationInfo")]
    public PlannerTeamsPublicationInfoModel? TeamsPublicationInfo { get; set; }
}
