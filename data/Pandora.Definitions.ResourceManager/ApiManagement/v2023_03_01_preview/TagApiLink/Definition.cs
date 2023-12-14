using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.TagApiLink;

internal class Definition : ResourceDefinition
{
    public string Name => "TagApiLink";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByProductOperation(),
        new WorkspaceTagApiLinkCreateOrUpdateOperation(),
        new WorkspaceTagApiLinkDeleteOperation(),
        new WorkspaceTagApiLinkGetOperation(),
        new WorkspaceTagApiLinkListByProductOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(TagApiLinkContractModel),
        typeof(TagApiLinkContractPropertiesModel),
    };
}
