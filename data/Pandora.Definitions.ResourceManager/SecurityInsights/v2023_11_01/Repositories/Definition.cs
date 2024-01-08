using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_11_01.Repositories;

internal class Definition : ResourceDefinition
{
    public string Name => "Repositories";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new SourceControllistRepositoriesOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(RepositoryAccessKindConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(RepoModel),
        typeof(RepositoryAccessModel),
        typeof(RepositoryAccessObjectModel),
        typeof(RepositoryAccessPropertiesModel),
    };
}
