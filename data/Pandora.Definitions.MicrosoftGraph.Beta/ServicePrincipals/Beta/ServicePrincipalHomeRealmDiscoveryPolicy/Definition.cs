// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.ServicePrincipals.Beta.ServicePrincipalHomeRealmDiscoveryPolicy;

internal class Definition : ResourceDefinition
{
    public string Name => "ServicePrincipalHomeRealmDiscoveryPolicy";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AddServicePrincipalByIdHomeRealmDiscoveryPolicyRefOperation(),
        new GetServicePrincipalByIdHomeRealmDiscoveryPolicyCountOperation(),
        new ListServicePrincipalByIdHomeRealmDiscoveryPoliciesOperation(),
        new ListServicePrincipalByIdHomeRealmDiscoveryPolicyRefsOperation(),
        new RemoveServicePrincipalByIdHomeRealmDiscoveryPolicyByIdRefOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
