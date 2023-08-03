// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PrivilegedAccessGroupEligibilityScheduleInstanceModel
{
    [JsonPropertyName("accessId")]
    public PrivilegedAccessGroupRelationshipsConstant? AccessId { get; set; }

    [JsonPropertyName("eligibilityScheduleId")]
    public string? EligibilityScheduleId { get; set; }

    [JsonPropertyName("endDateTime")]
    public DateTime? EndDateTime { get; set; }

    [JsonPropertyName("group")]
    public GroupModel? Group { get; set; }

    [JsonPropertyName("groupId")]
    public string? GroupId { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("memberType")]
    public PrivilegedAccessGroupMemberTypeConstant? MemberType { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("principal")]
    public DirectoryObjectModel? Principal { get; set; }

    [JsonPropertyName("principalId")]
    public string? PrincipalId { get; set; }

    [JsonPropertyName("startDateTime")]
    public DateTime? StartDateTime { get; set; }
}
