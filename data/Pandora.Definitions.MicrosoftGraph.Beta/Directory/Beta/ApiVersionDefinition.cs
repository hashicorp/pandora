// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Directory.Beta;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "Beta";
    public bool Preview => true;
    public Source Source => Source.MicrosoftGraphMetadata;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Directory.Definition(),
        new DirectoryAdministrativeUnit.Definition(),
        new DirectoryAdministrativeUnitExtension.Definition(),
        new DirectoryAdministrativeUnitMember.Definition(),
        new DirectoryAdministrativeUnitScopedRoleMember.Definition(),
        new DirectoryAttributeSet.Definition(),
        new DirectoryCertificateAuthority.Definition(),
        new DirectoryCertificateAuthorityCertificateBasedApplicationConfiguration.Definition(),
        new DirectoryCertificateAuthorityCertificateBasedApplicationConfigurationTrustedCertificateAuthority.Definition(),
        new DirectoryCustomSecurityAttributeDefinition.Definition(),
        new DirectoryCustomSecurityAttributeDefinitionAllowedValue.Definition(),
        new DirectoryDeletedItem.Definition(),
        new DirectoryFeatureRolloutPolicy.Definition(),
        new DirectoryFeatureRolloutPolicyAppliesTo.Definition(),
        new DirectoryFederationConfiguration.Definition(),
        new DirectoryImpactedResource.Definition(),
        new DirectoryInboundSharedUserProfile.Definition(),
        new DirectoryOnPremisesSynchronization.Definition(),
        new DirectoryOutboundSharedUserProfile.Definition(),
        new DirectoryOutboundSharedUserProfileTenant.Definition(),
        new DirectoryRecommendation.Definition(),
        new DirectoryRecommendationImpactedResource.Definition(),
        new DirectorySharedEmailDomain.Definition(),
        new DirectorySubscription.Definition()
    };
}
