// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Identity.StableV1.IdentityApiConnector;

internal class Definition : ResourceDefinition
{
    public string Name => "IdentityApiConnector";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateIdentityApiConnectorByIdUploadClientCertificateOperation(),
        new CreateIdentityApiConnectorOperation(),
        new DeleteIdentityApiConnectorByIdOperation(),
        new GetIdentityApiConnectorByIdOperation(),
        new GetIdentityApiConnectorCountOperation(),
        new ListIdentityApiConnectorsOperation(),
        new UpdateIdentityApiConnectorByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateIdentityApiConnectorByIdUploadClientCertificateRequestModel)
    };
}
