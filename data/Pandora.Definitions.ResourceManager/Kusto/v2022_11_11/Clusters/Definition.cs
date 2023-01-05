using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Kusto.v2022_11_11.Clusters;

internal class Definition : ResourceDefinition
{
    public string Name => "Clusters";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AddLanguageExtensionsOperation(),
        new CheckNameAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new DetachFollowerDatabasesOperation(),
        new DiagnoseVirtualNetworkOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new ListFollowerDatabasesOperation(),
        new ListLanguageExtensionsOperation(),
        new ListSkusByResourceOperation(),
        new RemoveLanguageExtensionsOperation(),
        new StartOperation(),
        new StopOperation(),
        new UpdateOperation(),
    };
}
