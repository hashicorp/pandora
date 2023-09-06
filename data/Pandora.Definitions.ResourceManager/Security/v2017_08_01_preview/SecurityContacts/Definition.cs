using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2017_08_01_preview.SecurityContacts;

internal class Definition : ResourceDefinition
{
    public string Name => "SecurityContacts";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AlertNotificationsConstant),
        typeof(AlertsToAdminsConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SecurityContactModel),
        typeof(SecurityContactPropertiesModel),
    };
}
