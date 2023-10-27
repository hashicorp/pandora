using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2023_11_01.Capabilities;

internal class Definition : ResourceDefinition
{
    public string Name => "Capabilities";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CapabilityTypesGetOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CapabilityModel),
        typeof(CapabilityPropertiesModel),
        typeof(CapabilityTypeModel),
        typeof(CapabilityTypePropertiesModel),
        typeof(CapabilityTypePropertiesRuntimePropertiesModel),
    };
}
