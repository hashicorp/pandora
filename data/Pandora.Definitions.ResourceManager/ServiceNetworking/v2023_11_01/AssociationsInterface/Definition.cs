using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceNetworking.v2023_11_01.AssociationsInterface;

internal class Definition : ResourceDefinition
{
    public string Name => "AssociationsInterface";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByTrafficControllerOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AssociationTypeConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AssociationModel),
        typeof(AssociationPropertiesModel),
        typeof(AssociationSubnetModel),
        typeof(AssociationSubnetUpdateModel),
        typeof(AssociationUpdateModel),
        typeof(AssociationUpdatePropertiesModel),
    };
}
