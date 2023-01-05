using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MySql.v2021_05_01.CheckNameAvailability;

internal class Definition : ResourceDefinition
{
    public string Name => "CheckNameAvailability";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ExecuteOperation(),
        new WithoutLocationExecuteOperation(),
    };
}
