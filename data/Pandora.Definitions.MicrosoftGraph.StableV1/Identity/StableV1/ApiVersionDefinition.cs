// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Identity.StableV1;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "StableV1";
    public bool Preview => false;
    public Source Source => Source.MicrosoftGraphMetadata;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Identity.Definition(),
        new IdentityApiConnector.Definition(),
        new IdentityB2xUserFlow.Definition(),
        new IdentityB2xUserFlowApiConnectorConfiguration.Definition(),
        new IdentityB2xUserFlowApiConnectorConfigurationPostAttributeCollection.Definition(),
        new IdentityB2xUserFlowApiConnectorConfigurationPostFederationSignup.Definition(),
        new IdentityB2xUserFlowIdentityProvider.Definition(),
        new IdentityB2xUserFlowLanguage.Definition(),
        new IdentityB2xUserFlowLanguageDefaultPage.Definition(),
        new IdentityB2xUserFlowLanguageOverridesPage.Definition(),
        new IdentityB2xUserFlowUserAttributeAssignment.Definition(),
        new IdentityB2xUserFlowUserAttributeAssignmentUserAttribute.Definition(),
        new IdentityB2xUserFlowUserFlowIdentityProvider.Definition(),
        new IdentityConditionalAcces.Definition(),
        new IdentityConditionalAccesAuthenticationContextClassReference.Definition(),
        new IdentityConditionalAccesAuthenticationStrength.Definition(),
        new IdentityConditionalAccesAuthenticationStrengthAuthenticationMethodMode.Definition(),
        new IdentityConditionalAccesAuthenticationStrengthPolicy.Definition(),
        new IdentityConditionalAccesAuthenticationStrengthPolicyCombinationConfiguration.Definition(),
        new IdentityConditionalAccesNamedLocation.Definition(),
        new IdentityConditionalAccesPolicy.Definition(),
        new IdentityConditionalAccesTemplate.Definition(),
        new IdentityIdentityProvider.Definition(),
        new IdentityUserFlowAttribute.Definition()
    };
}
