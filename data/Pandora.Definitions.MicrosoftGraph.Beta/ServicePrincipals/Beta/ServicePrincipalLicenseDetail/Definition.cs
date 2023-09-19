// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.ServicePrincipals.Beta.ServicePrincipalLicenseDetail;

internal class Definition : ResourceDefinition
{
    public string Name => "ServicePrincipalLicenseDetail";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateServicePrincipalByIdLicenseDetailOperation(),
        new DeleteServicePrincipalByIdLicenseDetailByIdOperation(),
        new GetServicePrincipalByIdLicenseDetailByIdOperation(),
        new GetServicePrincipalByIdLicenseDetailCountOperation(),
        new ListServicePrincipalByIdLicenseDetailsOperation(),
        new UpdateServicePrincipalByIdLicenseDetailByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
