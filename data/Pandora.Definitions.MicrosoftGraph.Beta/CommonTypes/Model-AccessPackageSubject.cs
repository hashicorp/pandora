// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AccessPackageSubjectModel
{
    [JsonPropertyName("altSecId")]
    public string? AltSecId { get; set; }

    [JsonPropertyName("cleanupScheduledDateTime")]
    public DateTime? CleanupScheduledDateTime { get; set; }

    [JsonPropertyName("connectedOrganization")]
    public ConnectedOrganizationModel? ConnectedOrganization { get; set; }

    [JsonPropertyName("connectedOrganizationId")]
    public string? ConnectedOrganizationId { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("objectId")]
    public string? ObjectId { get; set; }

    [JsonPropertyName("onPremisesSecurityIdentifier")]
    public string? OnPremisesSecurityIdentifier { get; set; }

    [JsonPropertyName("principalName")]
    public string? PrincipalName { get; set; }

    [JsonPropertyName("subjectLifecycle")]
    public AccessPackageSubjectSubjectLifecycleConstant? SubjectLifecycle { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}
