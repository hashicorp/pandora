// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class DirectoryModel
{
    [JsonPropertyName("administrativeUnits")]
    public List<AdministrativeUnitModel>? AdministrativeUnits { get; set; }

    [JsonPropertyName("attributeSets")]
    public List<AttributeSetModel>? AttributeSets { get; set; }

    [JsonPropertyName("certificateAuthorities")]
    public CertificateAuthorityPathModel? CertificateAuthorities { get; set; }

    [JsonPropertyName("customSecurityAttributeDefinitions")]
    public List<CustomSecurityAttributeDefinitionModel>? CustomSecurityAttributeDefinitions { get; set; }

    [JsonPropertyName("deletedItems")]
    public List<DirectoryObjectModel>? DeletedItems { get; set; }

    [JsonPropertyName("deviceLocalCredentials")]
    public List<DeviceLocalCredentialInfoModel>? DeviceLocalCredentials { get; set; }

    [JsonPropertyName("featureRolloutPolicies")]
    public List<FeatureRolloutPolicyModel>? FeatureRolloutPolicies { get; set; }

    [JsonPropertyName("federationConfigurations")]
    public List<IdentityProviderBaseModel>? FederationConfigurations { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("impactedResources")]
    public List<ImpactedResourceModel>? ImpactedResources { get; set; }

    [JsonPropertyName("inboundSharedUserProfiles")]
    public List<InboundSharedUserProfileModel>? InboundSharedUserProfiles { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("onPremisesSynchronization")]
    public List<OnPremisesDirectorySynchronizationModel>? OnPremisesSynchronization { get; set; }

    [JsonPropertyName("outboundSharedUserProfiles")]
    public List<OutboundSharedUserProfileModel>? OutboundSharedUserProfiles { get; set; }

    [JsonPropertyName("recommendations")]
    public List<RecommendationModel>? Recommendations { get; set; }

    [JsonPropertyName("sharedEmailDomains")]
    public List<SharedEmailDomainModel>? SharedEmailDomains { get; set; }

    [JsonPropertyName("subscriptions")]
    public List<CompanySubscriptionModel>? Subscriptions { get; set; }
}
