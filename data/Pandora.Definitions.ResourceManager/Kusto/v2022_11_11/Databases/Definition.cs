using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Kusto.v2022_11_11.Databases;

internal class Definition : ResourceDefinition
{
    public string Name => "Databases";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AddPrincipalsOperation(),
        new CheckNameAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByClusterOperation(),
        new ListPrincipalsOperation(),
        new RemovePrincipalsOperation(),
        new UpdateOperation(),
    };
}
