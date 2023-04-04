using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Orbital.v2022_11_01.Spacecraft;

internal class Definition : ResourceDefinition
{
    public string Name => "Spacecraft";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListBySubscriptionOperation(),
        new UpdateTagsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DirectionConstant),
        typeof(PolarizationConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AuthorizedGroundstationModel),
        typeof(SpacecraftModel),
        typeof(SpacecraftLinkModel),
        typeof(SpacecraftsPropertiesModel),
        typeof(TagsObjectModel),
    };
}
