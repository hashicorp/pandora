using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.LabServices.v2022_08_01.Usages;

internal class Definition : ResourceDefinition
{
    public string Name => "Usages";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListByLocationOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(UsageUnitConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(UsageModel),
        typeof(UsageNameModel),
    };
}
