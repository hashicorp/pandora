// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Identity.StableV1.IdentityB2xUserFlowApiConnectorConfigurationPostFederationSignup;

internal class Definition : ResourceDefinition
{
    public string Name => "IdentityB2xUserFlowApiConnectorConfigurationPostFederationSignup";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateIdentityB2xUserFlowByIdApiConnectorConfigurationPostFederationSignupUploadClientCertificateOperation(),
        new CreateUpdateIdentityB2xUserFlowByIdApiConnectorConfigurationPostFederationSignupRefOperation(),
        new DeleteIdentityB2xUserFlowByIdApiConnectorConfigurationPostFederationSignupOperation(),
        new GetIdentityB2xUserFlowByIdApiConnectorConfigurationPostFederationSignupOperation(),
        new GetIdentityB2xUserFlowByIdApiConnectorConfigurationPostFederationSignupRefOperation(),
        new RemoveIdentityB2xUserFlowByIdApiConnectorConfigurationPostFederationSignupRefOperation(),
        new UpdateIdentityB2xUserFlowByIdApiConnectorConfigurationPostFederationSignupOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateIdentityB2xUserFlowByIdApiConnectorConfigurationPostFederationSignupUploadClientCertificateRequestModel)
    };
}
