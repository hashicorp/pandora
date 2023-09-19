// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class MembershipOutlierInsightModel
{
    [JsonPropertyName("container")]
    public DirectoryObjectModel? Container { get; set; }

    [JsonPropertyName("containerId")]
    public string? ContainerId { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("insightCreatedDateTime")]
    public DateTime? InsightCreatedDateTime { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public UserModel? LastModifiedBy { get; set; }

    [JsonPropertyName("member")]
    public DirectoryObjectModel? Member { get; set; }

    [JsonPropertyName("memberId")]
    public string? MemberId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("outlierContainerType")]
    public MembershipOutlierInsightOutlierContainerTypeConstant? OutlierContainerType { get; set; }

    [JsonPropertyName("outlierMemberType")]
    public MembershipOutlierInsightOutlierMemberTypeConstant? OutlierMemberType { get; set; }
}
