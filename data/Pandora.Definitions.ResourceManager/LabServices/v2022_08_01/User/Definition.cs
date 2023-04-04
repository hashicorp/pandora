using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.LabServices.v2022_08_01.User;

internal class Definition : ResourceDefinition
{
    public string Name => "User";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new InviteOperation(),
        new ListByLabOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(InvitationStateConstant),
        typeof(ProvisioningStateConstant),
        typeof(RegistrationStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(InviteBodyModel),
        typeof(UserModel),
        typeof(UserPropertiesModel),
        typeof(UserUpdateModel),
        typeof(UserUpdatePropertiesModel),
    };
}
