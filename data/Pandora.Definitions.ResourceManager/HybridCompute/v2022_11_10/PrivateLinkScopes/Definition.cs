using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HybridCompute.v2022_11_10.PrivateLinkScopes;

internal class Definition : ResourceDefinition
{
    public string Name => "PrivateLinkScopes";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new PrivateLinkScopesCreateOrUpdateOperation(),
        new PrivateLinkScopesDeleteOperation(),
        new PrivateLinkScopesGetOperation(),
        new PrivateLinkScopesGetValidationDetailsOperation(),
        new PrivateLinkScopesGetValidationDetailsForMachineOperation(),
        new PrivateLinkScopesListOperation(),
        new PrivateLinkScopesListByResourceGroupOperation(),
        new PrivateLinkScopesUpdateTagsOperation(),
    };
}
