using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Orbital.v2022_11_01.Contact;

internal class Definition : ResourceDefinition
{
    public string Name => "Contact";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new SpacecraftsListAvailableContactsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ContactsStatusConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AvailableContactsModel),
        typeof(ContactModel),
        typeof(ContactInstancePropertiesModel),
        typeof(ContactParametersModel),
        typeof(ContactsPropertiesModel),
        typeof(ContactsPropertiesAntennaConfigurationModel),
        typeof(ResourceReferenceModel),
    };
}
