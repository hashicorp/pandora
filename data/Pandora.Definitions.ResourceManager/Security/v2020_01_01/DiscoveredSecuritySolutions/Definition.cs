using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.DiscoveredSecuritySolutions;

internal class Definition : ResourceDefinition
{
    public string Name => "DiscoveredSecuritySolutions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListOperation(),
        new ListByHomeRegionOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ConnectionTypeConstant),
        typeof(SecurityFamilyConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DiscoveredSecuritySolutionModel),
        typeof(DiscoveredSecuritySolutionPropertiesModel),
    };
}
