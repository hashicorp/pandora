using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Orbital.v2022_03_01.ContactProfile;

internal class Definition : ResourceDefinition
{
    public string Name => "ContactProfile";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ContactProfilesCreateOrUpdateOperation(),
        new ContactProfilesDeleteOperation(),
        new ContactProfilesGetOperation(),
        new ContactProfilesListOperation(),
        new ContactProfilesListBySubscriptionOperation(),
        new ContactProfilesUpdateTagsOperation(),
    };
}
