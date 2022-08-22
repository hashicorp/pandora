using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.DeletedService;

internal class Definition : ResourceDefinition
{
    public string Name => "DeletedService";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetByNameOperation(),
        new ListBySubscriptionOperation(),
        new PurgeOperation(),
    };
}
