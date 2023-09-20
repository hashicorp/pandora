// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecurityModel
{
    [JsonPropertyName("alerts")]
    public List<AlertModel>? Alerts { get; set; }

    [JsonPropertyName("alerts_v2")]
    public List<SecurityAlertModel>? Alertsv2 { get; set; }

    [JsonPropertyName("attackSimulation")]
    public AttackSimulationRootModel? AttackSimulation { get; set; }

    [JsonPropertyName("cases")]
    public SecurityCasesRootModel? Cases { get; set; }

    [JsonPropertyName("cloudAppSecurityProfiles")]
    public List<CloudAppSecurityProfileModel>? CloudAppSecurityProfiles { get; set; }

    [JsonPropertyName("domainSecurityProfiles")]
    public List<DomainSecurityProfileModel>? DomainSecurityProfiles { get; set; }

    [JsonPropertyName("fileSecurityProfiles")]
    public List<FileSecurityProfileModel>? FileSecurityProfiles { get; set; }

    [JsonPropertyName("hostSecurityProfiles")]
    public List<HostSecurityProfileModel>? HostSecurityProfiles { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("incidents")]
    public List<SecurityIncidentModel>? Incidents { get; set; }

    [JsonPropertyName("informationProtection")]
    public SecurityInformationProtectionModel? InformationProtection { get; set; }

    [JsonPropertyName("ipSecurityProfiles")]
    public List<IpSecurityProfileModel>? IpSecurityProfiles { get; set; }

    [JsonPropertyName("labels")]
    public SecurityLabelsRootModel? Labels { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("providerStatus")]
    public List<SecurityProviderStatusModel>? ProviderStatus { get; set; }

    [JsonPropertyName("providerTenantSettings")]
    public List<ProviderTenantSettingModel>? ProviderTenantSettings { get; set; }

    [JsonPropertyName("secureScoreControlProfiles")]
    public List<SecureScoreControlProfileModel>? SecureScoreControlProfiles { get; set; }

    [JsonPropertyName("secureScores")]
    public List<SecureScoreModel>? SecureScores { get; set; }

    [JsonPropertyName("securityActions")]
    public List<SecurityActionModel>? SecurityActions { get; set; }

    [JsonPropertyName("subjectRightsRequests")]
    public List<SubjectRightsRequestModel>? SubjectRightsRequests { get; set; }

    [JsonPropertyName("threatIntelligence")]
    public SecurityThreatIntelligenceModel? ThreatIntelligence { get; set; }

    [JsonPropertyName("threatSubmission")]
    public SecurityThreatSubmissionRootModel? ThreatSubmission { get; set; }

    [JsonPropertyName("tiIndicators")]
    public List<TiIndicatorModel>? TiIndicators { get; set; }

    [JsonPropertyName("triggerTypes")]
    public SecurityTriggerTypesRootModel? TriggerTypes { get; set; }

    [JsonPropertyName("triggers")]
    public SecurityTriggersRootModel? Triggers { get; set; }

    [JsonPropertyName("userSecurityProfiles")]
    public List<UserSecurityProfileModel>? UserSecurityProfiles { get; set; }
}
