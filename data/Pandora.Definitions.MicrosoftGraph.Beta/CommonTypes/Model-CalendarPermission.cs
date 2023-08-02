// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CalendarPermissionModel
{
    [JsonPropertyName("allowedRoles")]
    public List<CalendarRoleTypeConstant>? AllowedRoles { get; set; }

    [JsonPropertyName("emailAddress")]
    public EmailAddressModel? EmailAddress { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isInsideOrganization")]
    public bool? IsInsideOrganization { get; set; }

    [JsonPropertyName("isRemovable")]
    public bool? IsRemovable { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("role")]
    public CalendarRoleTypeConstant? Role { get; set; }
}
