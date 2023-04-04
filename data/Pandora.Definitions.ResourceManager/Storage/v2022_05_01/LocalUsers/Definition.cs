using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2022_05_01.LocalUsers;

internal class Definition : ResourceDefinition
{
    public string Name => "LocalUsers";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListKeysOperation(),
        new RegeneratePasswordOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(LocalUserModel),
        typeof(LocalUserKeysModel),
        typeof(LocalUserPropertiesModel),
        typeof(LocalUserRegeneratePasswordResultModel),
        typeof(LocalUsersModel),
        typeof(PermissionScopeModel),
        typeof(SshPublicKeyModel),
    };
}
