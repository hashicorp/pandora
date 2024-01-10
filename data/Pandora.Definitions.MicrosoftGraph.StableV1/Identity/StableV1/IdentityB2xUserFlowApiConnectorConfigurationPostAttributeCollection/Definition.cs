// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Identity.StableV1.IdentityB2xUserFlowApiConnectorConfigurationPostAttributeCollection;

internal class Definition : ResourceDefinition
{
    public string Name => "IdentityB2xUserFlowApiConnectorConfigurationPostAttributeCollection";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateIdentityB2xUserFlowByIdApiConnectorConfigurationPostAttributeCollectionUploadClientCertificateOperation(),
        new CreateUpdateIdentityB2xUserFlowByIdApiConnectorConfigurationPostAttributeCollectionRefOperation(),
        new DeleteIdentityB2xUserFlowByIdApiConnectorConfigurationPostAttributeCollectionOperation(),
        new GetIdentityB2xUserFlowByIdApiConnectorConfigurationPostAttributeCollectionOperation(),
        new GetIdentityB2xUserFlowByIdApiConnectorConfigurationPostAttributeCollectionRefOperation(),
        new RemoveIdentityB2xUserFlowByIdApiConnectorConfigurationPostAttributeCollectionRefOperation(),
        new UpdateIdentityB2xUserFlowByIdApiConnectorConfigurationPostAttributeCollectionOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateIdentityB2xUserFlowByIdApiConnectorConfigurationPostAttributeCollectionUploadClientCertificateRequestModel)
    };
}
