// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AuthenticationMethodsPolicyModel
{
    [JsonPropertyName("authenticationMethodConfigurations")]
    public List<AuthenticationMethodConfigurationModel>? AuthenticationMethodConfigurations { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("policyMigrationState")]
    public AuthenticationMethodsPolicyPolicyMigrationStateConstant? PolicyMigrationState { get; set; }

    [JsonPropertyName("policyVersion")]
    public string? PolicyVersion { get; set; }

    [JsonPropertyName("reconfirmationInDays")]
    public int? ReconfirmationInDays { get; set; }

    [JsonPropertyName("registrationEnforcement")]
    public RegistrationEnforcementModel? RegistrationEnforcement { get; set; }

    [JsonPropertyName("reportSuspiciousActivitySettings")]
    public ReportSuspiciousActivitySettingsModel? ReportSuspiciousActivitySettings { get; set; }

    [JsonPropertyName("systemCredentialPreferences")]
    public SystemCredentialPreferencesModel? SystemCredentialPreferences { get; set; }
}
