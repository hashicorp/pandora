// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MultiTenantOrganizationMemberTransitionDetailsModel
{
    [JsonPropertyName("desiredRole")]
    public MultiTenantOrganizationMemberTransitionDetailsDesiredRoleConstant? DesiredRole { get; set; }

    [JsonPropertyName("desiredState")]
    public MultiTenantOrganizationMemberTransitionDetailsDesiredStateConstant? DesiredState { get; set; }

    [JsonPropertyName("details")]
    public string? Details { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("status")]
    public MultiTenantOrganizationMemberTransitionDetailsStatusConstant? Status { get; set; }
}
