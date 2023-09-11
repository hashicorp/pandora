using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.GroupUser;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupUser";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckEntityExistsOperation(),
        new CreateOperation(),
        new DeleteOperation(),
        new ListOperation(),
        new WorkspaceGroupUserCheckEntityExistsOperation(),
        new WorkspaceGroupUserCreateOperation(),
        new WorkspaceGroupUserDeleteOperation(),
        new WorkspaceGroupUserListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(GroupTypeConstant),
        typeof(UserStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(GroupContractPropertiesModel),
        typeof(UserContractModel),
        typeof(UserContractPropertiesModel),
        typeof(UserIdentityContractModel),
    };
}
