using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagedServices.v2022_10_01.RegistrationAssignments;


internal class RegistrationAssignmentPropertiesRegistrationDefinitionPropertiesModel
{
    [JsonPropertyName("authorizations")]
    public List<AuthorizationModel>? Authorizations { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("eligibleAuthorizations")]
    public List<EligibleAuthorizationModel>? EligibleAuthorizations { get; set; }

    [JsonPropertyName("managedByTenantId")]
    public string? ManagedByTenantId { get; set; }

    [JsonPropertyName("managedByTenantName")]
    public string? ManagedByTenantName { get; set; }

    [JsonPropertyName("manageeTenantId")]
    public string? ManageeTenantId { get; set; }

    [JsonPropertyName("manageeTenantName")]
    public string? ManageeTenantName { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("registrationDefinitionName")]
    public string? RegistrationDefinitionName { get; set; }
}
