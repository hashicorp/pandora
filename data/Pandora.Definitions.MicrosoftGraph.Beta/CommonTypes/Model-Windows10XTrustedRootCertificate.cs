// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class Windows10XTrustedRootCertificateModel
{
    [JsonPropertyName("assignments")]
    public List<DeviceManagementResourceAccessProfileAssignmentModel>? Assignments { get; set; }

    [JsonPropertyName("certFileName")]
    public string? CertFileName { get; set; }

    [JsonPropertyName("creationDateTime")]
    public DateTime? CreationDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("destinationStore")]
    public CertificateDestinationStoreConstant? DestinationStore { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("roleScopeTagIds")]
    public List<string>? RoleScopeTagIds { get; set; }

    [JsonPropertyName("trustedRootCertificate")]
    public string? TrustedRootCertificate { get; set; }

    [JsonPropertyName("version")]
    public int? Version { get; set; }
}
