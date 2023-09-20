// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AccessPackageResourceAttributeModel
{
    [JsonPropertyName("attributeDestination")]
    public AccessPackageResourceAttributeDestinationModel? AttributeDestination { get; set; }

    [JsonPropertyName("attributeName")]
    public string? AttributeName { get; set; }

    [JsonPropertyName("attributeSource")]
    public AccessPackageResourceAttributeSourceModel? AttributeSource { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isEditable")]
    public bool? IsEditable { get; set; }

    [JsonPropertyName("isPersistedOnAssignmentRemoval")]
    public bool? IsPersistedOnAssignmentRemoval { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
