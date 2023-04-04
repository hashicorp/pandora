using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ExtendedLocation.v2021_08_15.CustomLocations;

internal class Definition : ResourceDefinition
{
    public string Name => "CustomLocations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListEnabledResourceTypesOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(HostTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CustomLocationModel),
        typeof(CustomLocationPropertiesModel),
        typeof(CustomLocationPropertiesAuthenticationModel),
        typeof(EnabledResourceTypeModel),
        typeof(EnabledResourceTypePropertiesModel),
        typeof(EnabledResourceTypePropertiesTypesMetadataInlinedModel),
        typeof(PatchableCustomLocationsModel),
    };
}
