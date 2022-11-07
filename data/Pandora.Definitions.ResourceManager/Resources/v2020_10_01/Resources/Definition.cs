using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2020_10_01.Resources;

internal class Definition : ResourceDefinition
{
    public string Name => "Resources";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckExistenceOperation(),
        new CheckExistenceByIdOperation(),
        new CreateOrUpdateOperation(),
        new CreateOrUpdateByIdOperation(),
        new DeleteOperation(),
        new DeleteByIdOperation(),
        new GetOperation(),
        new GetByIdOperation(),
        new ListOperation(),
        new MoveResourcesOperation(),
        new UpdateOperation(),
        new UpdateByIdOperation(),
        new ValidateMoveResourcesOperation(),
    };
}
