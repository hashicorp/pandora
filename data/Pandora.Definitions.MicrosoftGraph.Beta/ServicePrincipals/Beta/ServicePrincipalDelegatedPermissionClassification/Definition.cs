// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.ServicePrincipals.Beta.ServicePrincipalDelegatedPermissionClassification;

internal class Definition : ResourceDefinition
{
    public string Name => "ServicePrincipalDelegatedPermissionClassification";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateDelegatedPermissionClassificationOperation(),
        new DeleteDelegatedPermissionClassificationOperation(),
        new GetDelegatedPermissionClassificationOperation(),
        new GetServicePrincipalDelegatedPermissionClassificationsCountOperation(),
        new ListDelegatedPermissionClassificationsOperation(),
        new UpdateDelegatedPermissionClassificationOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
