// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.ServicePrincipals.Beta.ServicePrincipalOauth2PermissionGrant;

internal class Definition : ResourceDefinition
{
    public string Name => "ServicePrincipalOauth2PermissionGrant";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOauth2PermissionGrantOperation(),
        new GetServicePrincipalOauth2PermissionGrantsCountOperation(),
        new ListOauth2PermissionGrantsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
