// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class OnPremisesPublishingModel
{
    [JsonPropertyName("alternateUrl")]
    public string? AlternateUrl { get; set; }

    [JsonPropertyName("applicationServerTimeout")]
    public string? ApplicationServerTimeout { get; set; }

    [JsonPropertyName("applicationType")]
    public string? ApplicationType { get; set; }

    [JsonPropertyName("externalAuthenticationType")]
    public OnPremisesPublishingExternalAuthenticationTypeConstant? ExternalAuthenticationType { get; set; }

    [JsonPropertyName("externalUrl")]
    public string? ExternalUrl { get; set; }

    [JsonPropertyName("internalUrl")]
    public string? InternalUrl { get; set; }

    [JsonPropertyName("isAccessibleViaZTNAClient")]
    public bool? IsAccessibleViaZTNAClient { get; set; }

    [JsonPropertyName("isBackendCertificateValidationEnabled")]
    public bool? IsBackendCertificateValidationEnabled { get; set; }

    [JsonPropertyName("isHttpOnlyCookieEnabled")]
    public bool? IsHttpOnlyCookieEnabled { get; set; }

    [JsonPropertyName("isOnPremPublishingEnabled")]
    public bool? IsOnPremPublishingEnabled { get; set; }

    [JsonPropertyName("isPersistentCookieEnabled")]
    public bool? IsPersistentCookieEnabled { get; set; }

    [JsonPropertyName("isSecureCookieEnabled")]
    public bool? IsSecureCookieEnabled { get; set; }

    [JsonPropertyName("isStateSessionEnabled")]
    public bool? IsStateSessionEnabled { get; set; }

    [JsonPropertyName("isTranslateHostHeaderEnabled")]
    public bool? IsTranslateHostHeaderEnabled { get; set; }

    [JsonPropertyName("isTranslateLinksInBodyEnabled")]
    public bool? IsTranslateLinksInBodyEnabled { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("onPremisesApplicationSegments")]
    public List<OnPremisesApplicationSegmentModel>? OnPremisesApplicationSegments { get; set; }

    [JsonPropertyName("segmentsConfiguration")]
    public SegmentConfigurationModel? SegmentsConfiguration { get; set; }

    [JsonPropertyName("singleSignOnSettings")]
    public OnPremisesPublishingSingleSignOnModel? SingleSignOnSettings { get; set; }

    [JsonPropertyName("useAlternateUrlForTranslationAndRedirect")]
    public bool? UseAlternateUrlForTranslationAndRedirect { get; set; }

    [JsonPropertyName("verifiedCustomDomainCertificatesMetadata")]
    public VerifiedCustomDomainCertificatesMetadataModel? VerifiedCustomDomainCertificatesMetadata { get; set; }

    [JsonPropertyName("verifiedCustomDomainKeyCredential")]
    public KeyCredentialModel? VerifiedCustomDomainKeyCredential { get; set; }

    [JsonPropertyName("verifiedCustomDomainPasswordCredential")]
    public PasswordCredentialModel? VerifiedCustomDomainPasswordCredential { get; set; }
}
