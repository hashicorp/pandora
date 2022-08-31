using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Kusto.v2021_08_27.DataConnections;

internal class Definition : ResourceDefinition
{
    public string Name => "DataConnections";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckNameAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new DataConnectionValidationOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByDatabaseOperation(),
        new UpdateOperation(),
    };
}
