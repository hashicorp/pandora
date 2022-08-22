using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.Reports;

internal class Definition : ResourceDefinition
{
    public string Name => "Reports";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListByApiOperation(),
        new ListByGeoOperation(),
        new ListByOperationOperation(),
        new ListByProductOperation(),
        new ListByRequestOperation(),
        new ListBySubscriptionOperation(),
        new ListByTimeOperation(),
        new ListByUserOperation(),
    };
}
