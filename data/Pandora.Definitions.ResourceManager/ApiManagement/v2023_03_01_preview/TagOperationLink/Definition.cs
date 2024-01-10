using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.TagOperationLink;

internal class Definition : ResourceDefinition
{
    public string Name => "TagOperationLink";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByProductOperation(),
        new WorkspaceTagOperationLinkCreateOrUpdateOperation(),
        new WorkspaceTagOperationLinkDeleteOperation(),
        new WorkspaceTagOperationLinkGetOperation(),
        new WorkspaceTagOperationLinkListByProductOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(TagOperationLinkContractModel),
        typeof(TagOperationLinkContractPropertiesModel),
    };
}
