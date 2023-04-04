using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2020_07_07.VCenter;

internal class Definition : ResourceDefinition
{
    public string Name => "VCenter";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DeleteVCenterOperation(),
        new GetAllVCentersInSiteOperation(),
        new GetVCenterOperation(),
        new PutVCenterOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(HealthErrorDetailsModel),
        typeof(VCenterModel),
        typeof(VCenterPropertiesModel),
    };
}
