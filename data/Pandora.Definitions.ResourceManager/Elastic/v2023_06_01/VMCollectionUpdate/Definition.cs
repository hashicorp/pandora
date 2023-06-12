using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Elastic.v2023_06_01.VMCollectionUpdate;

internal class Definition : ResourceDefinition
{
    public string Name => "VMCollectionUpdate";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new VMCollectionUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(OperationNameConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(VMCollectionUpdateModel),
    };
}
