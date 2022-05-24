using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceLinker.v2022_05_01.ServiceLinker;

internal class Definition : ResourceDefinition
{
    public string Name => "ServiceLinker";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new LinkerCreateOrUpdateOperation(),
        new LinkerGetOperation(),
        new LinkerListOperation(),
    };
}
