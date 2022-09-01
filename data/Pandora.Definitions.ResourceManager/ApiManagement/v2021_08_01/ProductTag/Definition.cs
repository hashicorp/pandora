using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.ProductTag;

internal class Definition : ResourceDefinition
{
    public string Name => "ProductTag";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new TagAssignToProductOperation(),
        new TagDetachFromProductOperation(),
        new TagGetByProductOperation(),
        new TagGetEntityStateByProductOperation(),
        new TagListByProductOperation(),
    };
}
