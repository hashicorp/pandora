// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AccessPackageAssignmentResourceRoleModel
{
    [JsonPropertyName("accessPackageAssignments")]
    public List<AccessPackageAssignmentModel>? AccessPackageAssignments { get; set; }

    [JsonPropertyName("accessPackageResourceRole")]
    public AccessPackageResourceRoleModel? AccessPackageResourceRole { get; set; }

    [JsonPropertyName("accessPackageResourceScope")]
    public AccessPackageResourceScopeModel? AccessPackageResourceScope { get; set; }

    [JsonPropertyName("accessPackageSubject")]
    public AccessPackageSubjectModel? AccessPackageSubject { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("originId")]
    public string? OriginId { get; set; }

    [JsonPropertyName("originSystem")]
    public string? OriginSystem { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
