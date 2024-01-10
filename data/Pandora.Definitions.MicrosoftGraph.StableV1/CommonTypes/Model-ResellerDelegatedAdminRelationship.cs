// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ResellerDelegatedAdminRelationshipModel
{
    [JsonPropertyName("accessAssignments")]
    public List<DelegatedAdminAccessAssignmentModel>? AccessAssignments { get; set; }

    [JsonPropertyName("accessDetails")]
    public DelegatedAdminAccessDetailsModel? AccessDetails { get; set; }

    [JsonPropertyName("activatedDateTime")]
    public DateTime? ActivatedDateTime { get; set; }

    [JsonPropertyName("autoExtendDuration")]
    public string? AutoExtendDuration { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("customer")]
    public DelegatedAdminRelationshipCustomerParticipantModel? Customer { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("duration")]
    public string? Duration { get; set; }

    [JsonPropertyName("endDateTime")]
    public DateTime? EndDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("indirectProviderTenantId")]
    public string? IndirectProviderTenantId { get; set; }

    [JsonPropertyName("isPartnerConsentPending")]
    public bool? IsPartnerConsentPending { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("operations")]
    public List<DelegatedAdminRelationshipOperationModel>? Operations { get; set; }

    [JsonPropertyName("requests")]
    public List<DelegatedAdminRelationshipRequestModel>? Requests { get; set; }

    [JsonPropertyName("status")]
    public ResellerDelegatedAdminRelationshipStatusConstant? Status { get; set; }
}
